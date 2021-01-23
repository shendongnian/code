    fc.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<BasicEntity>
    
    (autoMappingConf)          
    
                   .UseOverridesFromAssemblyOf<AccountMappingOverride>()
                   .Conventions.Add(
                        DefaultCascade.SaveUpdate(),
                        new DefaultStringLengthConvention(),
                        new DefaultDecimalConvention()))           
                    );
            
    
    fc.ExposeConfiguration(cfg => 
    
             cfg.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, 
    
    currentSessionContextClass))
    
      .ExposeConfiguration(cfg => 
    
             cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "120")
    
       );             
       
    return fc;
