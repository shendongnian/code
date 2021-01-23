    else
    {
        var value = (Enum)Enum.ToObject(assembly.GetType(propertyInfo.PropertyType.FullName), propertyInfo.GetValue(objeto, null));
        var type = EnumsResolver.Resolve(value.GetType());
        yield return new OracleParameter
        {
            ParameterName = columnAttribute.Name,
            Value = Convert.ChangeType(value, type)
        };
    }
