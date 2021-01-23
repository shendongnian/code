    string[] x = { "1", "2", "0", ",", "1", "2", "1", ",", "1", "2", "2" };
    string all = string.Join("", x); // "120,121,122"
    string[] parts = all.Split(','); // { "120", "121", "122" }
    int i = int.MinValue;            // variable which is used in below query
    int[] y = parts                                // LINQ query
        .Where(s => int.TryParse(s.Trim(), out i)) // filters out invalid strings
        .Select(s => i)                            // selects the parsed ints
        .ToArray();                                // creates the final array
 
