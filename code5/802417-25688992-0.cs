            ConfigurationSection mySection = config.GetSection("countoffiles");
            if (config.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    config.AppSettings.Settings["countoffiles"];
                if (customSetting != null)
                {
                    Response.Write(customSetting.Value);
                }
                else
                {
                    Console.WriteLine("No countoffiles application string");
                }
            }
