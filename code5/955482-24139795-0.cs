    public class Person {
      [XmlIgnore]
      public IPAddress MasterIP { get; set; }
      [XmlElement("MasterIP")]
      public string MasterIPForXml {
        get { return MasterIP.ToString(); }
        set { MasterIP = string.IsNullOrEmpty(value) ? null :
          IPAddress.Parse(value); 
        }
      }
    }
