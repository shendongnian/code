     private void CallSpFromCode()
     {
         var sqlConnectionString = "User ID=\"" + username + "\";pwd=\"" + pw + "\";Initial Catalog=master;Data Source=" + dataSource + ";";
         using (SqlConnection con = new SqlConnection(sqlConnectionString )) {
         using (SqlCommand cmd = new SqlCommand("ExplortBlobDataFromTable", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@columns", SqlDbType.VarChar).Value = "ID, BlobColumn,TextColumn";
          cmd.Parameters.Add("@table", SqlDbType.VarChar).Value = "BlobTable";
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }
