    public TModel FillNullWithBlankInstances<TModel>(TModel model) where TModel : class
    {
        var type = model.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in properties)
        {
            var value = prop.GetValue(model, null);
            if (value == null) // null property than create instance
            {
                Type t = prop.PropertyType;
                var instance = Activator.CreateInstance(t, false);
                prop.SetValue(model, instance);
            }
        }
        return model;
    }
