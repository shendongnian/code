    public bool CheckPropertyAttribute(Type type, string property, 
                                Type attributeType, string attProp, object value)
    {
        var prop = type.GetProperty(property);
        if (prop == null) return false;
        return CheckPropertyAttribute(prop, attributeType, attProp, value);
    }
    public bool CheckPropertyAttribute(PropertyInfo prop, Type attributeType,
                                       string attProp, object value){
       var att = prop.GetCustomAttributes(attributeType, true);
       if (att == null||!att.Any()) return false;
       var attProperty = attributeType.GetProperty(attProp);
       if (attProperty == null) return false;
       return object.Equals(attProperty.GetValue(att[0], null),value);
    }
