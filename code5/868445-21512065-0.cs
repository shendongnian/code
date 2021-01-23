    public static T Bind<T>(this T @this,
                    Dictionary<string, object> newValues,
                    params string[] exceptions) where T : class
    {
        var sourceType = @this.GetType();
        var binding = BindingFlags.Public | BindingFlags.Instance;
        foreach (var pair in newValues.Where(v => !exceptions.Contains(v.Key)))
        {
            if(pair.Key.Contains("."))
            {
                var property = sourceType.GetProperty(
                               pair.Key.Split('.').First(),
                               binding | BindingFlags.GetProperty);
                var value = property.GetValue(@this, null);
                value.Bind(new Dictionary<string, object>
                {
                    { 
                        String.Join(".", pair.Key.Split('.').Skip(1).ToArray()),
                        pair.Value
                    }
                });
            }
            else
            {
                var property = sourceType.GetProperty(pair.Key, 
                               binding | BindingFlags.SetProperty);
                var propType = Nullable.GetUnderlyingType(property.PropertyType) ??
                               property.PropertyType;
                property.SetValue(@this, (pair.Value == null) ? null :
                         Convert.ChangeType(pair.Value, propType), null);
            }
        }
        return @this;
    }
