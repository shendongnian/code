    public static void Main(params string[] args)
    {
        List<string> keys = new List<string>()  { 
            "REPORTMONTH", 
            "CONTRACT", "DATE", "AMOUNT",
            "CONTRACT", "DATE", "AMOUNT"
        };
        List<string> values = new List<string>() {   
            "01", 
            "ABC123", "01022014", "300.00", 
            "DEF345", "03042014", "400.00"
        }; 
        var pairs = keys.Select((key, ndx) => new { Key = key, Value = values[ndx] });
        var groups = pairs.GroupBy(e => e.Key)
            .ToDictionary(g => g.Key, g => g.Select(kvp => kvp.Value).ToArray());
        var dictionaries = new Dictionary<string, string>[groups.Max(g => g.Value.Length)];
        for (var i = 0; i < dictionaries.Length; i++)
        {
            dictionaries[i] = new Dictionary<string,string>();
            foreach (var g in groups) 
            {
                if (g.Value.Length == 1)
                    dictionaries[i][g.Key] = g.Value[0];
                else if (g.Value.Length > i)
                    dictionaries[i][g.Key] = g.Value[i];
            }
        }
        // print content
        for (var i = 0; i < dictionaries.Length; i++)
        {
            Console.WriteLine("Dictionary {0}:", i + 1);
            Console.WriteLine(string.Join(Environment.NewLine, dictionaries[i].Select(e => string.Format("{0} = {1}", e.Key, e.Value))));
            Console.WriteLine();
        }
        Console.ReadLine();
    }
