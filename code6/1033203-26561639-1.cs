    IDictionary<string, HashSet<string>> sets = new Dictionary<string, HashSet<string>>();
            sets.Add("Stage 1", new HashSet<string>{ "A","B","C"});
            sets.Add("Stage 2", new HashSet<string>{ "D","E"});
    public static bool GetAllowed(string stage,string status, IDictionary<string,HashSet<string>> allowedSets)
        {
            return allowedSets[stage].Contains(status);
        }
    Console.WriteLine(GetAllowed("Stage 1", "A", sets)); // returns true
    Console.WriteLine(GetAllowed("Stage 2", "A", sets)); //returns false
