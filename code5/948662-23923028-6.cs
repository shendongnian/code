    static public string SerializeToXML(List<Metric> metrics)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Metric>));
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, metrics);
 
            return writer.ToString();
        }
    }
