      try
      {    	
         string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");    
         sqlConnection = new SqlConnection(dbConnectionString);
         SqlCommand command = new SqlCommand("sp_checkTableExist", sqlConnection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add("@theDate", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
         sqlConnection.Open();
         int result = (Int32)command.ExecuteScalar();
         sqlConnection.Close();
         if (result == 1)
         return true;//or any message 
         else
         return false;    
      }
    catch (SqlException ex)
      {
         Console.WriteLine("SQL Error" + ex.Message.ToString());
         return false;
      }
