    private void Serialize<T>(object value)
    {
        XmlObjectSerializer serializer = new DataContractSerializer(typeof(T));
        var writer = new XmlTextWriter(Console.Out)
        {
            Formatting = Formatting.Indented
        };
        serializer.WriteObject(writer, value);
    }
