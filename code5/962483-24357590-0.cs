    public T DeserializeFragment<T>(string xmlFragment)
    {
        // Add a root element using the type name e.g. <MyData>...</MyData>
        var xmlData = string.Format("<{0}>{1}</{0}>", typeof(T).Name, xmlFragment);
        var mySerializer = new XmlSerializer(typeof(T));
        using (var reader = new StringReader(xmlData))
        {
            return (T)mySerializer.Deserialize(reader);
        }
    }
