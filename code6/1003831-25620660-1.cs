    XmlSerializer ser = new XmlSerializer(typeof(Message));
    using (StringWriter sww = new StringWriter())
    {
        using (XmlWriter writer = XmlWriter.Create(sww))
        {
            ser.Serialize(writer, new Message() { Outbox = "onething", Recipient = "another thing" });
            var xml = sww.ToString();
        }
    }
