    public static string GetElementName(BaseClass target)
    {
        XmlRootAttribute attribute = target.GetType().GetCustomAttribute<XmlRootAttribute>();
        return attribute == null ? null : attribute.ElementName;
    }
