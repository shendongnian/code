    string input = "-- [AUG-24-14 11:58 PM (EDT)  Mickey Rahman] --------------Comment 1-- [AUG-24-14 11:40 PM (EDT)  Mickey Rahman] --------------Comment 2-- [AUG-22-14 11:51 PM (EDT)  Automation User] --------------TEST 3";
    string pattern = @"(?=-- \[.+\])";
    
    string[] substrings = Regex.Split(input, pattern).Where(_=>_.Length > 0).ToArray();    // Split on hyphens 
    int i = 1;
    foreach (string match in substrings)
    {
        Console.WriteLine("MATCH " + i.ToString() + ":" + string.Format("{0}", match));
        i++;
    }
