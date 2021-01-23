     try 
     {
      con.Open();
      int TotalRowsAffected = command.ExecuteNonQuery();
     }
     catch(Exeception ex)
     {
       MessageBox.Show(ex.Message);
     }
     finaly
     {
      con.Close();
     } 
