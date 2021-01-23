    string data = "'({today} - ({date1} + {date2}))', 'user', 'info'"; // your string
    
    string pattern = @"\{.*?\}"; // pattern that will match everything in format {anything}
    Regex regEx = new Regex(pattern); //create regex using pattern
    
    MatchCollection matches; // create collection of matches
    matches = regEx.Matches(data); // get all matches from your string using regex
    
    for (int i = 0; i < matches.Count; i++) // use this cycle to check if it s what you need
    {
        Console.WriteLine("{0}", matches[i].Value);
    }
