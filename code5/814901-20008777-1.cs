    using (var dr = command.ExecuteReader()) 
    {
       if (dr.HasRows()) 
       {           
          string dateFormatted = today.ToString("MMddyyhhmmss");
          string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          var writer = new StreamWriter(String.Format("{0}\exclusion_{1}.csv",
             path, dateFormatted);
          
          var continue = true;
          while (continue) 
          {
             continue = reader.Read();
             
             var exclNum = reader.GetString(0);
             // Last record, don't add comma
             if (!continue) 
             {
                writer.Write(exclNum); 
             }
             else 
             { 
                writer.Write(exclNum + ",");
             }
          }
       }
    }
