    void Main()
    {
      var reader = File.ReadLines(@"file.txt");
      string directory = null;
        
        var lines = reader.Select (line => 
        {
          if (line.StartsWith("Directory"))
          {
            directory = line.Split(new[]{'\t'})[1];
            return null;
          }
        
          var lineParts = line.Split(new[]{'\t'});
          return new Line{ Date = lineParts[0], Time = lineParts[1], Bytes = lineParts[2], User = lineParts[3], Filename = Path.Combine(directory, lineParts[4]) };
        });
        
        lines.Where (l => l != null).Dump();
    }
    
    class Line
    {
      public string Date{get;set;}
      public string Time {get;set;}
      public string Bytes {get;set;}
      public string User {get;set;}
      public string Filename {get;set;}  
    }
