    public interface IPlugin
    {
        public IConfiguration CreateNewConfig();
        public void Configure(IConfiguration config);
    }
    void Test() 
    {
        IPlugin myPlugin = PluginFactory.CreateSomePlugin();
        IConfiguration pluginConfig = myPlugin.CreateNewConfig();
        InitializeConfigWithCoreSettings(pluginConfig);
        myPlugin.Configure(pluginConfig);
    }
