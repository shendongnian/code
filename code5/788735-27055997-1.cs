    public string ToXml(TaskListFilterConfig config)
    {
        XmlSerializer serializer = new XmlSerializer(typeOf(TaskListFilterConfig));
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, config);
            return writer.ToString();
        }
    }
