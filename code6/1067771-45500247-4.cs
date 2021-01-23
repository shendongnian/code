		Console.WriteLine("Local Config sections");
		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		Console.WriteLine("BEFORE[test]=" + config.AppSettings.Settings["test"].Value);
		Console.WriteLine("BEFORE[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
		
		config.AppSettings.Settings["test"].Value = "NEW";
		config.AppSettings.Settings["testExternalOnly"].Value = "NEWEXTERNAL";
		config.Save(ConfigurationSaveMode.Modified);
		//next line will throw an error as 'A section using 'configSource' may contain no other attributes or elements'
        // because of the failure to update the AppSettings.config file
        // but instead editing the app.exe.config file
        ConfigurationManager.RefreshSection("appSettings");
		//Shut current config
		config = null;
		//Open config
		config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		Console.WriteLine("AFTER[test]=" + config.AppSettings.Settings["test"].Value);
		Console.WriteLine("AFTER[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
		Console.WriteLine("AFTER CONFIG EXTERNAL FILE: " + System.IO.File.ReadAllText("AppSettings.config"));
		Console.WriteLine("AFTER CONFIG FILE: " + System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.FriendlyName + ".config"));
