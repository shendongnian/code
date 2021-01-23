    public class SQLServerDatabaseConnection : DatabaseConnection
    {
       public SQLServerDatabaseConnection(...) //Whatever params you want
       //Or public SQLServerDatabaseConnection(...) : base (...) //if base has required params
       {
       }
    
       public override void OpenConnection()
       {
       }
       
       ...//Overrides for every other pure virtual method
    }
