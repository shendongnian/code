    var lines= File.ReadAllLines(sPath);
    var regex = new Regex(String.Format("\b{0}\b", searchVariable));
    
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
