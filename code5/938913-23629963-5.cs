    public class User
    {
      public int Id{get; set;}
      public int? CountryId {get; set;}
      public virtual Country Country {get; set;}
      public string Name {get; set;}
    }
