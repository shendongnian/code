    String[] data = new String[] {
      "dec.02",
      "Novemeber-2",
      "Oct-6",
      ...
    };
    
    // All the indexes, if you want 1st only, change "ToArray()" into "First()"
    int[] indice = data
      .Select((line, index) => new {
         line = line,
         index = index})
      .Where(item => Regex.IsMatch(item.line, "Your regular expression"))
      .Select(item => item.index)
      .ToArray();
