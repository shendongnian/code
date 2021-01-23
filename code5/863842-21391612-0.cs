    private string GetValue(BloodStoredModel obj, string propertyName)
    {
        Type type = typeof(BloodStoredModel);
        if (type != null)
        {
            PropertyInfo property = type.GetProperty(propertyName);
            if (property != null)
            {
                return (string)property.GetValue(obj);
             }
        }
        return null;
    }
