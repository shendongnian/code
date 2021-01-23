    try {
    
      using (SqlConnection conn = new SqlConnection()) {
        conn.ConnectionString =
          "Data Source=(localdb)\\Instance;" +
          "Initial Catalog=Database;" +
          "User id=root;" +
          "Password=pass;";
    
        conn.Open();
    
        using (SqlCommand myCommand = new SqlCommand("INSERT INTO Database.dbo.Table" +
                                          "VALUES ('stg', 'stg1', 'stg2', 'stg3');", conn)) {
          myCommand.ExecuteNonQuery();
        }
      }
    } catch (Exception ex) {
      Console.WriteLine(ex.ToString());
    }
