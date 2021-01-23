    public class Player
    {
      //you need to define an identifier
      public int PlayerId {get;set;}
      public string Name {get; set;}
      public int Age {get; set;}
      public double Salary {get; set;}
      public string Gender {get; set;}
      public DateTime ContractSignDate {get; set;}
      //you need a foreignkey
      [ForeignKey("TeamId")]
      public Team Team {get;set;}
      public int TeamId {get;set;}
    }
