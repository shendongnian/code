    static List<Metric> DeserializeFromXML(string xmlString)
    {
       XmlSerializer deserializer = new XmlSerializer(typeof(List<Metric>));
       List<Metric> metrics; 
       metrics = (List<Metric>)deserializer.Deserialize(xmlString);
       return metrics;
    }
