    [Serializable]
    //[XmlRoot("Directories")]
    public class Directories
    {
        //[XmlElement("Directory")]
        public List<Directory> Directory { get; set; }
    }
    [Serializable]
    public class Directory
    {
        //[XmlAttribute()]
        public string Path { get; set; }
        //[XmlArray("Files")]
        //[XmlArrayItem("File")]
        public List<XmlFileInfo> Files { get; set; }
    }
    [Serializable]
    public class XmlFileInfo
    {
        //[XmlElement("File")]
        public string File { get; set; }
        //[XmlAttribute()]
        public MyobstruficatedEnum Type { get; set; }
    }
