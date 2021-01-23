    public class Client
    {
      public int ClientId { get; set; }
      public string ClientName { get; set; }
      public IList<Contact> Contacts { get; set; }
    }
    
    public class Contacts
    {
      public int ContactId { get; set; }
      public string ContactName { get; set; }
      public IList<Order> Order { get; set; }
    }
