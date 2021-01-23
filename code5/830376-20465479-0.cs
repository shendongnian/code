    public class CityBO : IDomainObject
    {
      public PrimaryKey Id { get; set; }
      public string Name { get; set; }
      public EntityReferance<CountryBO> Country { get; set; }
      public LocationInfoBO Location { get; set; }
      public StatusInfo Status { get; set; }  
    }
