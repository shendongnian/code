    abstract class LogItem    {       
        public String payload { get; set; }       
        public String serverId { get; set; }     
        public DateTime timeRecieved { get; set; }
    
    }
    
     class MyLogItem : LogItem
    {
      //No I want this to have to have the members from the abstract class above, as if it where an interface?
       private void TestMethod(){
         String test = payload;
       }
    }
