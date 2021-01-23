      If (DB.Connect("ConnectionString") != null) {
          //Connection successful
      }
      else {
         //Failed
      }
     public class DB
     {
         Static SqlConnection Connect(string connectionString)
         {
            SqlConnection thisConnection = null;
            try { 
              thisConnection = new SqlConnection(connectionString);
            }
            catch (SqlException e) { Console.WriteLine(e.Message); }
            return thisConnection;
    }
}
