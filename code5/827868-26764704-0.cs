    if (propertyType == typeof(int))
    {
        var value = (int)Convert.ChangeType(propertyInfo.GetValue(testo, null), propertyType);
    }
    else if(propertyType == typeof(string))
    {
        var value = (string)Convert.ChangeType(propertyInfo.GetValue(testo, null), propertyType);
    }
