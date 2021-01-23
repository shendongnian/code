    
    public static XElement SafeElement(this XElement element, XName name)
    {
        return element.Element(name) ?? new XElement(name);
    }
    
    public static XAttribute SafeAttribute(this XElement element, XName name)
    {
        return element.Attribute(name) ?? new XAttribute(name, string.Empty);
    }
