    public static class XmlSerializationHelper
    {
        public static string DefaultXmlElementName(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                return xmlType.TypeName;
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                return xmlRoot.ElementName;
            return type.Name;
        }
    }
