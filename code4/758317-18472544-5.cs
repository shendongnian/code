    void Main()
    {
      var lines = ReadFile();
      
      lines.ToList().ForEach (Console.WriteLine);
    }
    
    IEnumerable<Line> ReadFile()
    {
      using (var reader = new StreamReader(File.OpenRead(@"file.txt")))
      {
        const string directoryPrefix = " Directory of ";
        Regex splittingRegex = new Regex(@"\s+", RegexOptions.Compiled);
        string directory = null;
        string line;
        
        while ((line = reader.ReadLine()) != null)
        {
          line = line.TrimEnd();
          if (line.StartsWith(directoryPrefix))
          {
            directory = line.Substring(directoryPrefix.Length);
            continue;
          }
        
          // The "6" parameter means the regex will split the string into 6 parts at most--leaving the last column (filename) unsplit
          var lineParts = splittingRegex.Split(line, 6);
          yield return new Line{ Date = lineParts[0], Time = lineParts[1], Period = lineParts[2], Bytes = lineParts[3], User = lineParts[4], Filename = Path.Combine(directory, lineParts[5]) };
         }
      }
    }
    
    // Define other methods and classes here
    class Line
    {
      public string Date{get;set;}
      public string Time {get;set;}
      public string Period {get;set;}
      public string Bytes {get;set;}
      public string User {get;set;}
      public string Filename {get;set;}  
    }
