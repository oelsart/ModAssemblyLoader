#if LOADTEST
using ModAssemblyLoader;

namespace LoadTest;

public abstract class LoadMods
{
    protected AssemblyLoader loader;

    protected abstract string[] LoadFolders { get; }
    
    protected abstract string[] AssemblyNames { get; }

    [SetUp]
    public void SetUp()
    {
        loader = new AssemblyLoader(Configurations.Version, Configurations.RimWorld);
    }
    
    [Test]
    public virtual void LoadAssemblies()
    {
        foreach (var folder in LoadFolders)
        {
            loader.LoadModFolder(folder);
        }
        var nameList = loader.Assemblies.Select(assembly => assembly.GetName().Name).ToList();
        Assert.That(AssemblyNames.All(name => nameList.Contains(name)));
    }
}
#endif