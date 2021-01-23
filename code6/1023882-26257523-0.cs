    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class MeterWalkOrder
    {
      public string Name { get; set; }
      [System.Xml.Serialization.XmlArrayItemAttribute("Meter", IsNullable = false)]
      public List<MeterWalkOrderMeter> Meters { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class MeterWalkOrderMeter
    {
      public int MeterID { get; set; }
      public string SerialNumber { get; set; }
    }
