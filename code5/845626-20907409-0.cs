    config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());
----------
    public class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> defaultProbedAssemblies = base.GetAssemblies();
            //TODO: filter out the assemblies that you do not want to be probed
            return defaultProbedAssemblies;
        }
    }
