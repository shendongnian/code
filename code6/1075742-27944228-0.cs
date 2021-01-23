    public class DatabaseManagement
    {
       Logger logger;
       // Other properties and fields
       
       public DatabaseManagement()
       {
         this.logger = new Logger(this);
         // Other constructor stuff
       }
       // Other methods
    }
    
    public class Logger
    {
      DatabaseManagement dbManagement;
      // Other properties and fields
     
      public Logger(DatabaseManagement dbManagement)
      {
        this.dbManagement = dbManagement;
        // other constructor stuff
      }
    
      // Other methods
    }
