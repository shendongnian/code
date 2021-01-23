    public class Claim 
    {
      public Source Source { get; set; }
      public Driver Driver { get; set; }
      public Owner Owner { get; set; }
      public Vehicle Vehicle { get; set; }
      public Accident Accident { get; set; }
      public Policy Policy { get; set; }
      public Insurer Insurer { get; set; }
      public Solicitor Solicitor { get; set; }
      [XmlElement]
      public List<ThirdParty> ThirdParty { get; set; } 
    }
