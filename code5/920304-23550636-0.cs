    // TODO: Change class name to reflect document name
    public class ShipToDetails
    {
       public string Id { get; set; }
       public string Name { get; set; }
       public string Code { get; set;
    
       public int Area { get; set; }
       public string Capital { get; set; }
       public string Province { get; set; }
       public string FlagId { get; set; }
       public string ContinentCode { get; set; }
    
       public Address ShipTo { get; set; }
    }
    
    public class Address
    {
       public string Line1 { get; set; }
       public string Line2 { get; set; }
       public string City { get; set; }
       public string Region { get; set; }
       public string PostalCode { get; set; }
       public string Country { get; set; }
    }
