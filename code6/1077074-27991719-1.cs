     using System.Xml.Serialization;
     public class Header
     {
       [XmlElement(DataType = "integer", ElementName = "HeaderID")]
       int ID{get;set;}
     }
