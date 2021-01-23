    static void Main(string[] args)
    {
        var list = new List<Object21>
        {
           // initialize your list
        };
    
        foreach (var object21 in list)
        {
            object21.Process();
        }
    
        // Calculate your occurrences (basically what @Grant Winney suggested)
        var occurrences = list.GroupBy(o => o.Key).ToDictionary(g => g.Key, g => (g.Count() / (double)list.Count)*100);
    
        foreach (var occurrence in occurrences)
        {
            Console.WriteLine("{0}: {1}%", occurrence.Key, occurrence.Value);
        }
    }
