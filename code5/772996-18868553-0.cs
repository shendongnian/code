    public class BaseEntity
    {
      Guid LastUpdatedBy {get; set;}  
      DateTime LastUpdatedOn {get; set;}
    }
    public class Client: BaseEntity
    {
      Guid ClientId {get; set;}    
    }
