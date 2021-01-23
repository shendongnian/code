    private static string GetConfigValue(XContainer parent, XName name)
    {
        var element = parent.Element(name);
    
        if (element == null)
            throw new ArgumentException(string.Format("Invalid configuration file, missing element {0}", name));
    
        return element.Value;
    }
