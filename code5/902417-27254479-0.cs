    public TCloned CloneProperties<TSource, TCloned>(TSource sourceObj)
    {
        var propertoiesToClone = typeof(TCloned).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        var clonedInstance = (TCloned)Activator.CreateInstance(typeof(TCloned));
    
        var sourceProperties = typeof(TSource).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
    
        foreach (var prop in propertoiesToClone)
        {
            var appropriatePropery = sourceProperties.SingleOrDefault(p => p.Name == prop.Name);
    
            if (appropriatePropery != null)
            {
                prop.SetValue(clonedInstance, appropriatePropery.GetValue(sourceObj));
            }
        }
    
        return clonedInstance;    
    }
