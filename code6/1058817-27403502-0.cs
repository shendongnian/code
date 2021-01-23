    [XmlElement("File1")]
    public List<string> File1 { get; set; }
    [XmlElement("File2")]
    public List<string> File2 { get; set; }
    [XmlElement("File3")]
    public List<string> File3 { get; set; }
    [XmlIgnore]
    public List<string> FileObject
    {
       get { return this.File1 ?? this.File2 ?? this.File3; }
    }
