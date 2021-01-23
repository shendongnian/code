    try {
       using(var conn = new OleDbConnection(...)) {
          using(var command = new OleDbCommand("SELECT password ...", conn)) {
             conn.Open();
             using(var reader = command.ExecuteReader(...)) {
                if(reader.Read()) {
                   return reader.GetString(0);
                }
             }
          }
       }
    }
    catch(Exception ex) {
       Logger.Error(ex);  // REPORT ERROR! DONT EAT IT
    }
