    [XmlType("Foo")]
    public class Foo {
      [XmlArray("Items")]
      [XmlArrayItem("Item")]
      public List<string> Data {get; set;}
    }
