    abstract class LogItem    {       
        public abstract String payload { get; set; }       
        public abstract String serverId { get; set; }     
        public abstract DateTime timeRecieved { get; set; }
    
    }
    
     class MyLogItem : LogItem
    {
      //No I want this to have to have the members from the abstract class above, as if it where an interface?
    }
