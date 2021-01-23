    var serializer = new XmlSerializer(typeof(T));
     using (XmlWriter xmlWriter = XmlWriter.Create(stream, writerSettings))
     {
        serializer.Serialize(xmlWriter, obj);
     }
    
    
    var serializer = new XmlSerializer(typeof(T));
    result = (T)serializer.Deserialize(stream);
    
    
    [Serializable]
    public class Settings
         
    
    public class TaxRates
    {
        [XmlElement(ElementName = "TaxRate")]
        public decimal ReturnTaxRate;
    }
