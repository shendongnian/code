    string[] partNumbers = { "US","UK", "Australia","Germany", "1", "70", "9" };
    var result = partNumbers.Select(s => {
                      int value;
                      bool isNumber = Int32.TryParse(s, out value);
                      return new { isNumber, s, value };
                   }).GroupBy(x => x.isNumber)
                     .OrderBy(g => g.Key)
                     .SelectMany(g => g.Key ? g.OrderBy(x => x.value) : 
                                              g.OrderBy(x => x.s))
                     .Select(x => x.s)
                     .ToList();
