    public class PluginFactory : IPluginFactory {
        private readonly IEnumerable<IPlugin> plugins;
        public PluginFactory(IEnumerable<IPlugin> plugins) {
            this.plugins = plugins;
        }
        public IPlugin GetPluginByName(string name) {
            return this.plugins.Single(plugin => plugin.Name == name);
        }
    }
