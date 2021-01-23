    static string Serialize(SomeType[] values)
    {
        using (var sw = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(SomeType[]));
            serializer.Serialize(sw, values);
            return sw.ToString();
        }
    }
