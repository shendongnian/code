        foreach (var property in sourceType.GetProperties())
        {
            var targetProperty = targetType.GetProperty(property.Name);
            if (targetProperty == null)
            {  
                DynamicType.CreateProperty(tb, property.Name, property.GetType());
            }
        }
