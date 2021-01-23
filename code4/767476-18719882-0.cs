        string folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
        config.ConnectionStrings.ConnectionStrings["myCS"].ConnectionString = config.ConnectionStrings.ConnectionStrings["myCS"].ConnectionString.Replace("#folder#",folder);
    
        config.Save(ConfigurationSaveMode.Full, true);
    
