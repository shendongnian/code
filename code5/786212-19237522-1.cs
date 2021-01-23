    var lines= File.ReadAllLines(sPath);
    var regex = new Regex(@"\b\d{4}\b");
    
    if (lines.Any())
    {
     using (var streamWriter = File.AppendText(rPath))
     {    
      foreach (var line in lines) 
      {
       if (regex.IsMatch(line))
       {
        streamWriter.WriteLine(line);
       }  
      }
     }
    }
