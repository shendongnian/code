    // Attribute on Property
    [DataMember(Name = "code"), XmlAttribute]
    public string Code{ get; set; }
    // ...
    // Deserialization
    XmlSerializer serializer = new XmlSerializer(typeof(Level1));
    // ...
    Level1 p = (Level1)serializer.Deserialize(reader);
