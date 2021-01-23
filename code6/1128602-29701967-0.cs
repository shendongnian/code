    [System.Xml.Serialization.XmlRoot(ElementName="TotalRecords")]
    public class TotalRecords
    {
      [System.Xml.Serialization.XmlElement(ElementName="Recs")]
      public Recs recs { get; set; }
      [System.Xml.Serialization.XmlAttribute(AttributeName = "ItineraryCount")]
      public string ItineraryCount { get; set; }
    }
    public partial class Recs
    {
      [System.Xml.Serialization.XmlElement(ElementName = "Amount")]
      public string amountField { get; set; }
      [System.Xml.Serialization.XmlElement(ElementName = "TravelTime")]
      public string travelTimeField { get; set; }
      [System.Xml.Serialization.XmlElement(ElementName = "FSegment")]
      public FSegment fSegmentField { get; set; }
      [System.Xml.Serialization.XmlAttribute(AttributeName = "ItineraryNumber")]
      public string itineraryNumberField { get; set; }
    }
    public class FSegment
    {
      [System.Xml.Serialization.XmlElement(ElementName = "OutProperty")]
      public SegmentList OutProperty { get; set; }
    }
    public class SegmentList
    {
      [System.Xml.Serialization.XmlElement(ElementName = "Segment")]
      public List<Segment> segmentField { get; set; }
    }
    public class Segment
    {
      [System.Xml.Serialization.XmlElement(ElementName = "Name")]
      public string nameField { get; set; }
      [System.Xml.Serialization.XmlElement(ElementName = "City")]
      public string cityField { get; set; }
      [System.Xml.Serialization.XmlElement(ElementName = "Country")]
      public string countryField { get; set; }
      [System.Xml.Serialization.XmlAttribute(AttributeName = "No")]
      public int segmentNoField { get; set; }
    }
