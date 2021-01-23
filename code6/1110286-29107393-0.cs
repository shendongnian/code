      public class Client
      {
         public int ClientID { get; set; }
         public string Name { get; set; }
         public int ClientTypeID { get; set; }
         public ClientType ClientType { get; set; }
      }
      public class ClientType
      {
         public int ClientTypeID { get; set; }
         public string Description { get; set; }
      }
