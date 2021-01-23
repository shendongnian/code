            Console.WriteLine("Local Config sections");
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Console.WriteLine("[test]=" + config.AppSettings.Settings["test"].Value);
                Console.WriteLine("[testExternalOnly]=" + config.AppSettings.Settings["testExternalOnly"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("press the ENTER key to end");
            Console.ReadLine();
