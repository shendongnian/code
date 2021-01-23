    string test = "1Hello World  2I'm a newbie 33The sun is big 176The cat is black";
    
    Regex regexObj = new Regex(@"(\d+)([^0-9]+)", RegexOptions.IgnoreCase);
    Match match = regexObj.Match(test);
    while (match.Success) 
    {
      string numPart = match.Group[1].Value;
      string strPart = match.Group[2].Value;
      match = match.NextMatch();
    }
