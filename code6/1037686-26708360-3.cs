    private object lockObj = new object();
    
    private void UpdateListView(string query)
    {
      command.Connection = connection;
      insertinto = "1";
      command.CommandText = "Update ReaderUHF Set Identification = '" + insertinto + "' where EPC = '" + query + "'";
      lock(lockObj)
      {
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
      }
      showdata(insertinto);              
    }
        
    //After 3 seconds. This thread is performed while the main thread is running
        
    private void FinalLocation()
    {
      command_1.Connection = connection_1;
      finaLoc = "Outside";
      command_1.CommandText = "Update ReaderUHF Set Location = '" + insertinto + "' where EPC = '" + query + "'";
      lock(lockObj)
      {
        connection_1.Open();
        command_1.ExecuteNonQuery();
        connection_1.Close();
      }            
    }
