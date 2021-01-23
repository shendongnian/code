    public class PluginAssemblyLocator : DefaultAssemblyLocator
    {
        private readonly IEnumerable<Assembly> _pluginAssemblies;
        public PluginAssemblyLocator(IEnumerable<Assembly> pluginAssemblies)
        {
            _pluginAssemblies = pluginAssemblies;
        }
        public override IList<Assembly> GetAssemblies()
        {
            return base.GetAssemblies().Union(_pluginAssemblies).ToList();
        }
    }
