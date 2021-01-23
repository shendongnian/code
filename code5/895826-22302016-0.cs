    using(OleDbConnection cn = new OleDbConnection(connstring))
    using(OleDbCommand cmd = new OleDbCommand("Customers_FindAll", cn))
    {
         cn.Open();
         cmd.CommandType = CommandType.StoredProcedure;
         using(OleDbDataReader reader = cmd.ExecuteReader())
         {
              while(reader.Read())
              {
                  // use the reader data.....
              }
         }
    }
