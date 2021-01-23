    public partial class User{
       public User(){       
           this.Events = new HashSet<Event>();
       }
    
       public Guid UserId {get;set;}
       public string Name {get;set;}
       //...other properties as needed
       public virtual ICollection<Event> Events {get;set;}
    }
    
    public partial class Event{
       public int EventId {get;set;}
       public Guid UserId {get;set;}
       //...other properties
       public virtual User User {get;set;}
    }
