    List<object> items = new List<object>();
    string data = "a, 1, 1.5, b";
    
    Regex.Matches(data, "[^,]+") // Get each object without a comma over the line.
         .OfType<Match>()
         .Select (mt => mt.ToString().Trim()) // Remove any whitespace (if any)
         .ToList()
         .ForEach(itm => items.Add(Regex.IsMatch(itm, "[a-zA-Z]")  ?          // Is it
                                                (object) itm :                // a string
                                                (object) Double.Parse(itm))); // a number
    
    Console.WriteLine ( string.Join( " | ", items.Select (obj => obj.ToString())));
    // Writes:
    // a | 1 | 1.5 |  b
    
    Console.WriteLine ( string.Join( ", ", items.Select (obj => obj.GetType())));
    // Writes:
    // System.String, System.Double, System.Double, System.String
