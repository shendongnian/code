    public void WriteXml (XmlWriter writer)
    {
        writer.WriteString(Others);
        //And so on for HelperContainer.Foo and Bar
    }
    public void ReadXml (XmlReader reader)
    {
        Others = reader.ReadString();
        //...
    }
