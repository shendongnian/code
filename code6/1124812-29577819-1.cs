       var tenantIdentificationStrategy = container.Resolve<ITenantIdentificationStrategy>();
       var tid = tenantIdentificationStrategy.IdentifyTenant<string>();
       mtc.ConfigureTenant(tid ,
             containerBuilder =>
             {
                 containerBuilder.RegisterModule(new ConfigurationSettingsReader(tid));
                 // or something like that which identifies the tenant config section
             }
       );
