    var regex = new Regex ("(\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}) - (.*?) \\(Work notes\\)");
    var lines = str.split(new char[] {'\n'});
    foreach (var line in lines)
    {
      var match = regex.Match(line);
      if (match.Success)
      {
        for (var i = 0; i < match.Groups.Count; i++)
        {
          Console.WriteLine('>' + match.Groups[i].Value);
        }
        // will preface the body after each header
        Console.WriteLine(">");
      }
      else
      {
        Console.WriteLine(line);
      }
    }
