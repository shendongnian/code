    void Main()
    {
      var lines = ReadFile();
      
      // Do something with the parsed data (you could override Line.ToString() here to get a usable console output)
      lines.ToList().ForEach (Console.WriteLine);
    }
    
    IEnumerable<Line> ReadFile()
    {
      using (var reader = new StreamReader(File.OpenRead(@"file.txt")))
      {
        string directory = null;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          if (line.StartsWith("Directory"))
          {
            directory = line.Split(new[]{'\t'})[1];
            continue;
          }
        
          var lineParts = line.Split(new[]{'\t'});
          yield return new Line{ Date = lineParts[0], Time = lineParts[1], Bytes = lineParts[2], User = lineParts[3], Filename = Path.Combine(directory, lineParts[4]) };
        }
      }
    }
    
    // Define other methods and classes here
    class Line
    {
      public string Date{get;set;}
      public string Time {get;set;}
      public string Bytes {get;set;}
      public string User {get;set;}
      public string Filename {get;set;}  
    }
