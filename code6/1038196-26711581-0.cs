    var props = new MyModel()
        .GetType()
        .GetProperties()
        .Where(prop =>
            {
                var fieldAttribute = prop.GetCustomAttribute<FieldAttribute>();
                if (fieldAttribute != null)
                {
                    return fieldAttribute.FieldFor == FieldFor.Name;
                }
    
                return false;
            })
        .ToList();
