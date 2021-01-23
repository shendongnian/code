    [XmlType("Data")]
    public class Data {
      [XmlElement("Title")]
      public string Title {get; set; }
      [XmlArray("Comp")]
      [XmlArrayItem("CompItem")]
      public List<CompItem> Comp {get; set; }
    }
