    public class CustomAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var assemblies = base.GetAssemblies();
            var controllersAssembly = Assembly.LoadFrom(@"C:\PATH_TO_MY_CONTROLLERS_ASSEMBLY");
            assemblies.Add(controllersAssembly);
            return assemblies;
        }
    }
