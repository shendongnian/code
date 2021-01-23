      var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = Application.StartupPath + Path.DirectorySeparatorChar + @"app.config" }; // application name must be
      using (var unityContainer = new UnityContainer())
      {
        var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
        unityContainer.LoadConfiguration(unitySection, "ConnectionString");
        {
         unityContainer.Resolve<IDBConnectionSettings>();
         .... 
         ....
