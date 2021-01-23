    public void InsertImportantMsg (string msg, DateTime toDay, int visible) {
      connection.Open();
    
      // Put IDisposable into using...
      using (var cmd = connection.CreateCommand()) {
        // Format query to be readble
        cmd.CommandText = 
          @"UPDATE IMPORTANTMESSAGE
               SET MESSAGES = :msg, -- <- you don't need apostrophes here...
                   DATETIME = :toDay,
                   LABELVISIBILITY = :visible";
       
        cmd.Parameters.Add(":msg", msg);
        cmd.Parameters.Add(":toDay", toDay);
        //TODO: Check this - Oracle doesn't support boolean is SQL 
        cmd.Parameters.Add(":visible", visible);  
    
        cmd.ExecuteNonQuery(); 
      }
    }
