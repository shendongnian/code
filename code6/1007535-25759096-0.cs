               .UseOverridesFromAssemblyOf<AccountMappingOverride>()
               .Conventions.Add(
                    DefaultCascade.SaveUpdate(),
                    new DefaultStringLengthConvention(),
                    new DefaultDecimalConvention()))           
                );
        
