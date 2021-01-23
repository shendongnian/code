    public void Serialize(BinaryWriter writer)  // signature defined by interface
    {
        var serializer = new XmlSerializer(this.GetType());
        serializer.Serialize(writer.BaseStream, this);
    }
