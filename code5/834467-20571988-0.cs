    public TTarget MapToViewModel<TSource, TTarget>(TSource source)
        where TTarget : new()
    {
        var sourceType = source.GetType();
        var targetProperties = typeof(TTarget).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var sourceMethods = sourceType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        
        var target = Activator.CreateInstance<TTarget>();
        foreach (var prop in targetProperties)
        {
            var sourceProp = sourceProperties.FirstOrDefault(x => x.Name == prop.Name);
            if (sourceProp != null)
            {
                prop.SetValue(target, sourceProp.GetValue(source, null), null);
            }
            else
            {
                var sourceMethod = sourceMethods.FirstOrDefault(x => x.Name == "Get" + prop.Name);
                if (sourceMethod != null)
                {
                    prop.SetValue(target, sourceMethod.Invoke(source, null), null);
                }
            }
        }
        return target;
    }
