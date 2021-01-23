		Console.WriteLine("Local Config sections");
		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		Console.WriteLine("BEFORE[test]=" + config.AppSettings.Settings["test"].Value);
		Console.WriteLine($"BEFORE[testExternalOnly]={config.AppSettings.Settings["testExternalOnly"]?.Value}");
		//to avoid: Error CS0266
		//Explicitly cast 'System.Configuration.AppSettingsSection'
		AppSettingsSection myAppSettings = (AppSettingsSection)config.GetSection("appSettings");
		myAppSettings.Settings["test"].Value = "NEW";
		if (!myAppSettings.Settings.AllKeys.Contains("testExternalOnly"))
		    myAppSettings.Settings.Add("testExternalOnly", "NEWEXTERNAL");
		config.Save(ConfigurationSaveMode.Modified);
		ConfigurationManager.RefreshSection("appSettings");
		//Shut current config
		config = null;
		//Open config
		config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		Console.WriteLine("AFTER[test]=" + config.AppSettings.Settings["test"].Value);
		Console.WriteLine("AFTER[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
		Console.WriteLine("AFTER CONFIG EXTERNAL FILE: " + System.IO.File.ReadAllText("App.Settings.config"));
		Console.WriteLine("AFTER CONFIG FILE: " + System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.FriendlyName + ".config"));
