        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Local Config sections");
                var exepath = (new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
                Configuration config = ConfigurationManager.OpenExeConfiguration(exepath);
                
                config.AppSettings.SectionInformation.ConfigSource = "App.Settings.config";
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
                //Read updated config
                Console.WriteLine("AFTER[test]=" + config.AppSettings.Settings["test"].Value);
                Console.WriteLine("AFTER[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
                Console.WriteLine("AFTER CONFIG EXTERNAL FILE: " + System.IO.File.ReadAllText("App.Settings.config"));
                Console.WriteLine("AFTER CONFIG FILE: " + System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.FriendlyName + ".config"));
                //Shut current config
                config = null;
                //Open config
                config = ConfigurationManager.OpenExeConfiguration(exepath);
                config.AppSettings.SectionInformation.ConfigSource = "App.Settings.config";
                Console.WriteLine("AFTER[test]=" + config.AppSettings.Settings["test"].Value);
                Console.WriteLine("AFTER[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
                Console.WriteLine("AFTER CONFIG EXTERNAL FILE: " + System.IO.File.ReadAllText("App.Settings.config"));
                Console.WriteLine("AFTER CONFIG FILE: " + System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.FriendlyName + ".config"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("press the ENTER key to end");
            Console.ReadLine();
        }
