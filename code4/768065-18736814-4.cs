     public class DBConnectionSettings()
     {
       get ConnectionString
       {
           var connections = ConfigurationManager.ConnectionStrings;
           // From app.config you will get the connection string
           var connectionString = connections["ConnectionString"].ConnectionString;
 
         return connectionString;
       }
     }
