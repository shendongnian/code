    void LoadPlugin(string fullPath)
    {
    Assembly assembly = Assembly.FromFile(fullPath);
    //class that provides methods for registering plugins
    IPluginRegistrationService registration = new PluginRegistrationService();
    assembly.EntryPoint.Invoke(null,new object[] { registration });
    }
