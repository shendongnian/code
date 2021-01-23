    public class Connection
    {
       public SqlConnection Function()
       {
          var connetionString = /*your connection string*/
          return new SqlConnection(connetionString);
       }
    }
