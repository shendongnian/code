    static XmlAttributeOverrides GenerateXmlAttributeOverrides(Type type)
    {
        XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
        foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if ((propertyInfo.PropertyType.IsPrimitive || propertyInfo.PropertyType == typeof(string)) &&
                !propertyInfo.GetCustomAttributes().Any(a => a.GetType() == typeof(XmlElementAttribute) ||
                                                             a.GetType() == typeof(XmlAttributeAttribute)))
                xmlAttributeOverrides.Add(type, propertyInfo.Name, new XmlAttributes { XmlAttribute = new XmlAttributeAttribute() });
        }
        return xmlAttributeOverrides;
    }
