    class SomeClass
    {
     public static void Main(String[] args)
     {
      using (SqlConnection sqlConn = new SqlConnection("some connection string"))
      {
       sqlConn.Open();
    
       using (SqlCommand comm = new SqlCommand("some query; some other query;", conn))
       using (var sqlReader = comm.ExecuteReader())
       {
        while (sqlReader.Read())
        {
         //some stuff here
        }
        if(sqlReader.NextResult())
        {
          while (sqlReader.Read())
          {
           //some other stuff here
          }
         }
        }
      }
     }
    }
