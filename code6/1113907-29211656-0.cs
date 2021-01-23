    var idToNames = new Dictionary<string, List<Tuple<string, string>>>
    {
        {
            "3084",
            new List<Tuple<string, string>>
                {
                    Tuple.Create("Female", "Femme"),
                    Tuple.Create("Male", "Homme"),
                    Tuple.Create("Other", "Autre"),
                }
        },
        {
            "1033",
            new List<Tuple<string, string>>
                {
                    Tuple.Create("Female", "Woman"),
                    Tuple.Create("Male", "Man"),
                    Tuple.Create("Other", "Other"),
                }
        }
    };
    var nameToSpecific = 
        idToNames.SelectMany(
            kvp => kvp.Value.Select(
                t => new 
                { 
                    LCID = kvp.Key, 
                    GenericName = t.Item1, 
                    SpecificName = t.Item2 
                }))
        .GroupBy(x => x.GenericName)
        .ToDictionary(
            g => g.Key, 
            g => g.Select(
                x => Tuple.Create(x.LCID, x.SpecificName)).ToList());
    foreach (var kvp in nameToSpecific)
    {
        Console.WriteLine(kvp.Key);
        foreach(var tup in kvp.Value)
            Console.WriteLine("    " + tup);
    }
