    public static string SerializeToXml<T>(this T obj)
    {
        var serializer = new DataContractSerializer(obj.GetType());
        using (var writer = new StringWriter())
        using (var stm = new XmlTextWriter(writer))
        {
            serializer.WriteObject(stm, obj);
            return writer.ToString();
        }
    }
