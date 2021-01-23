    var settingsManager = new SettingsManager(new SqlSettingManager("connStr"));
    container.RegisterSingle<ISettingsManager>(settingsManager);
    container.Register<ICommunicationClient, CommunicationClient>();
    string url = settingsManager.GetSetting("url");
    string userName = settingsManager.GetSetting("username");
    string password = settingsManager.GetSetting("password");
    container.Register<IServerConfiguration>(() => 
          new ServerConfiguration(url, userName, password));
