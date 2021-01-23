    using System.Data.SqlClient;
    using Microsoft.SqlServer.Server; 
    
    public class StoredProcedures 
    {
       [Microsoft.SqlServer.Server.SqlProcedure]
       public static void HelloWorld()
       {
          SqlContext.Pipe.Send("Hello world! It's now " + System.DateTime.Now.ToString()+"\n");
          using(SqlConnection connection = new SqlConnection("context connection=true")) 
          {
             connection.Open();
             SqlCommand command = new SqlCommand("SELECT ProductNumber FROM ProductMaster", connection);
             SqlDataReader reader = command.ExecuteReader();
             SqlContext.Pipe.Send(reader);
          }
       }
    }
