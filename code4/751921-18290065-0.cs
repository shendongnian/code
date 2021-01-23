    foreach (var propertyInfo in myPropertyInfo)
    {
        if (propertyInfo.GetIndexParameters().Length == 0)
        {
            value = (string) propertyInfo.GetValue(objeto, null);
            dictionary.Add(propertyInfo.Name.ToString(), value);
        }
    }
