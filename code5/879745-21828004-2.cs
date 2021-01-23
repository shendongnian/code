    public class CustomAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var assemblies = base.GetAssemblies();
            var controllersAssembly = typeof(SomeTypeFromControllersLibrary).Assembly;
            assemblies.Add(controllersAssembly);
            return assemblies;
        }
    }
