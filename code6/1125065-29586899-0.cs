    //You can add, remove or change filters
    var tempDictionary = new Dictionary<string, bool>
    {
        {"USA", true},
        {"Australia", false},
        {"UK", true},
        {"China", false},
    };
    //Get relevant filters
    var tempFilter = tempDictionary
                     .Where(item => item.Value)
                     .Select(item => item.Key)
                     .ToArray();
    var tempPeople = db
                     .People
                     .Where(x => tempFilter.Contains(x.Country));
