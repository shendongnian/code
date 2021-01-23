       mtc.ConfigureTenant("mytenant1",
             containerBuilder =>
             {
                 containerBuilder.RegisterModule(new ConfigurationSettingsReader("mytenant1"));
             }
       );
       mtc.ConfigureTenant("mytenant2",
             containerBuilder =>
             {
                 containerBuilder.RegisterModule(new ConfigurationSettingsReader("mytenant2"));
             }
       );
