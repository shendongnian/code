    string parsedLine= null;
    foreach (var line in lines)
    {
      parsedLine = line.Substring(51,171);
      parsedLine = parsedLine.Replace("%3A", ":");
      parsedLine = ...
    }
    //use parsedLine here...
