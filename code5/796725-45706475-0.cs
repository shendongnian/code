    ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                    configMap.ExeConfigFilename = modulePath + "Web.Release.config";
                    System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                    System.Configuration.ConfigurationSection section = config.GetSection("connectionStrings");
                    if (!section.SectionInformation.IsProtected)
                    {
                                       section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                        config.Save();
                    }
