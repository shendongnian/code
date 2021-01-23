    var dictionary = new Dictionary<string, int>()
    {
        {"1",5},         
        {"2",3},
        {"3",2},
        {"4",1},
        {"5",1},
    };
    var max = dictionary.Values.Max();
    int percent = 50;
    int percentageValue = max*percent /100;
    var topItems = dictionary.OrderByDescending(entry => entry.Value)
           .TakeWhile(x => x.Value > percentageValue)
           .ToDictionary(pair => pair.Key, pair => pair.Value);
    foreach (var item in topItems)
    {
        Console.WriteLine(item.Value);
    }
