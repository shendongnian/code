    public class MyNewAssembliesResolver : DefaultAssembliesResolver
    {
        public virtual ICollection<Assembly> GetAssemblies()
        {
            
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom(@"Path_to_Controller_DLL");
            baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;
        }
    }
