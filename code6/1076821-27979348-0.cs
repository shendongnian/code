    [XmlRoot("settings")]
     public class Settings
     {
    [XmlElement("calculator")]
     public Calculator calculator { get; set; }
    [XmlArray("features")]
    [XmlArrayItem("feature")]
     public List<Feature> features{get;set;}
    }
    public class Calculator 
    {
    [XmlAttribute]
     public string display{ get; set; }
    }
