    try {
        var x = ConfigurationManager.ConnectionStrings;   //blows up             
    }
    catch {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.Sections.Remove("connectionStrings");
        config.Save(); //Now save the changes
        ConfigurationManager.RefreshSection("connectionStrings"); //and reload the section
        var x = ConfigurationManager.ConnectionStrings; //can now read!                
    }
