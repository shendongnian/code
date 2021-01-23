    var allLines  = File.ReadAllLines(path);
    var listOfPersons = new List<Person>();
    foreach(var line in allLines)
    {
        var splittedLines = line.Split(new[] {","})
         if(splittedLines!=null && splittedLines.Any())
          {
              listOfPersons.Add( new Person {
                                               Name = splittedLines[0],
                                               Email = splittedLines .Length > 1 ?splittedLines[1]:null,
                                                Phone = splittedLines .Length > 2? splittedLines[2]:null,
                                             });
          }
       
    }
