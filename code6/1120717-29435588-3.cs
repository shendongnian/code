    public TModel FillNullWithBlankInstances<TModel>(TModel model) where TModel : class
    {
        var type = model.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in properties)
        {
            var value = prop.GetValue(model, null);
            if (value == null) // null property than create instance
            {
                var instance = Activator.CreateInstance( prop.PropertyType, false);
                prop.SetValue(model, instance);
            }
        }
        return model;
    }
