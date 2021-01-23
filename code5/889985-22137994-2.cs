       sqlConnection.Open();
       sqlCommand.Connection = sqlConnection;
       sqlCommand.CommandType = CommandType.Text;
       sqlCommand.CommandText = "your SQL Statement";
       sqlCommand.Parameters.Add("@param1", SqlDbType.VarChar).Value = adparam[0];
       sqlCommand.Parameters.Add("@param2", SqlDbType.VarChar).Value = adparam[1];
       sqlCommand.Parameters.Add("@Param3", SqlDbType.VarChar).Value = adparam[2];
       sqlCommand.ExecuteNonQuery();
       SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
       Dataset ds = new DataSet();
       sda.Fill(ds);
       dg.DataSource = ds.Tables[0];
       bs.DataSource = ds.Tables[0]
      
