    //your object
    public class LogItem {
       public LogItem(string message, string description, string status) {
          Message = message;
          Description = description;
          Status = status;
       }
       public System.DateTime OccurredOn { get; set; }
       public string Message { get; set; }
       public string Description { get; set; }
       public string Status { get; set; }
    }
    
    public interface ILogFactory {
       LogItem CreateNew(string message, string description, string status);
    }
    
    public class LogFactory: ILogFactory {
       private readonly IClock clock;
       public LogFactory(IClock clock) {
          Requires.IsNotNull(clock, "clock");
          this.clock = clock;
       }
       public LogItem CreateNew(string message, string description, string status) {
          var item = new LogItem (message, description, status);
          item.OccurredOn = clock.Now();
          return item;
       }
    }
    
    public interface IClock {
       System.DateTime Now();
    }
