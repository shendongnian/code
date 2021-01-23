    public class Findings
    {
      [System.Xml.Serialization.XmlElementAttribute("finding")]
      public List<Finding> finding = new List<Finding>();
    }
    public class Finding
    {
      public string issue1;
      public string issue2;
      public string issue3;
    }
