    Regex matcherRegex = new Regex("(Summer)|(Winter)|(^Exterior|ParkFacilities$)", 
                                   RegexOptions.Compiled);
    string Matcher(string input)
    {
      var m = matcherRegex.Match(input);
    
      if (m.Groups.Count == 4)
      {
        if (m.Groups[0].Success) return "Summer";
        else if (m.Groups[1].Success) return "Winter";
        else if (m.Groups[2].Success) return "Outdoors";
      }
    
      return null;
    }
