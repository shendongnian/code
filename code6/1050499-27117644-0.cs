    foreach (object x in (IEnumerable)dto)
    {
        var propertyInfo = dto.GetType().GetProperty(x.ShortDescript,
               BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (propertyInfo != null)
        { 
            propertyInfo.SetValue(dto, x.DataValue);
        }
    }
