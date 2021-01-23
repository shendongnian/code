    SetConfig();
    var webApp1Config = ConfigurationManager.GetSection("WebApp1") as NameValueCollection;
    var webApp2Config = ConfigurationManager.GetSection("WebApp2") as NameValueCollection;
    private static void SetConfig()
    {
        AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"C:\Temp\web.config");
        var fieldInfo = typeof(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static);
        if (fieldInfo != null)
            fieldInfo.SetValue(null, 0);
        var field = typeof(ConfigurationManager).GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static);
        if (field != null)
            field.SetValue(null, null);
        var info = typeof(ConfigurationManager).Assembly.GetTypes().First(x => x.FullName == "System.Configuration.ClientConfigPaths").GetField("s_current", BindingFlags.NonPublic | BindingFlags.Static);
        if (info != null)
            info.SetValue(null, null);
    }
