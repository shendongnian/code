    var lines = s.Split(
                    new[] { Environment.NewLine }, 
                    StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
    // pairing thanks to http://stackoverflow.com/questions/1624341/
    var dictionary = lines.Where((x, i) => i < lines.Count)
                          .Select((x, i) => 
                              new KeyValuePair<string, string>(
                                  x.Trim('[', ']'), // get rid of brackets
                                  lines[i + 1]))
                          .ToDictionary();
    var productCode = dictionary["Product code"];
