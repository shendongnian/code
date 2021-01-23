    [Export(typeof(IRegisterDemo))] // <-- This exports RegisterDemo as IRegisterDemo
    public class RegisterDemo : IRegisterDemo { }
    // Example method to register assemblies with ContainerBuilder
    public void RegisterPartsFromReferencedAssemblies(ContainerBuilder builder)
    {
        // Get referenced assemblies
        var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
        
        // Create an AssemblyCatalog from each assembly
        var assemblyCatalogs = assemblies.Select(x => new AssemblyCatalog(x));
        // Combine all AssemblyCatalogs into an AggregateCatalog
        var catalog = new AggregateCatalog(assemblyCatalogs);
        // Register the catalog with the ContainerBuilder
        builder.RegisterComposablePartCatalog(catalog);
    }
