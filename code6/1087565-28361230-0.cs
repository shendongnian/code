      public void AddToDatabase(string strAccessSelect)
          {
             try
             {
                myAccess.Open();
                OleDbCommand OleDbUpdateCommand = new OleDbCommand(strAccessSelect, myAccess);
                OleDbUpdateCommand.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                error = "Couldn't fetch the required data. " + ex.Message;
             }
             finally
             {
                myAccessConn.Close();
             }
          }
      
  
