    var lines= File.ReadAllLines(sPath);
    var regex = new Regex(@"\b\d{4}\b");
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
