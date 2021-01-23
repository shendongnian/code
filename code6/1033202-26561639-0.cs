    IDictionary<string, string> sets = new Dictionary<string, string>();
            sets.Add("Stage 1", "A,B,C");
            sets.Add("Stage 2", "D,E");
    public static bool GetAllowed(string stage,string status,ref IDictionary<string,string> allowedSets)
        {
            return allowedSets[stage].Contains(status);
        }
    Console.WriteLine(GetAllowed("Stage 1", "A", ref sets)); // returns true
    Console.WriteLine(GetAllowed("Stage 2", "A", ref sets)); //returns false
