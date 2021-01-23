     [Serializable]
     [XmlRoot("lot_information")]
     public class LotInformation
     {
      
      Public LotInformation
      {
        Components = new List<Components>();
        Families = new List<Families>();
      }
    
     [Key]
     public int Id { get; set; }
     [XmlArray("components")]
     [XmlArrayItem("component", typeof(Components))]
     public List<Components> Components { get; set; }
     [XmlArray("families")]
     [XmlArrayItem("control", typeof(Families))]
     public List<Families> Families { get; set; }
     ....
    }
