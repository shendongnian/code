    using (var dr = command.ExecuteReader()) 
    {
       if (dr.HasRows()) 
       {           
          string dateFormatted = today.ToString("MMddyyhhmmss");
          string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          var writer = new StreamWriter(String.Format("{0}\exclusion_{1}.csv",
             path, dateFormatted);
          
          var cont = true;
          while (cont) 
          {
             // Grab the accountid before we read ahead
             var accId = reader["accountid"];
             // Read ahead to check if we've read the last record
             cont = reader.Read();
             // Last record, don't add comma
             if (!cont) 
             {
                writer.Write(accId); 
             }
             else 
             { 
                writer.Write(accId + ",");
             }
          }
       }
    }
