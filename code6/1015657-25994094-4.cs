    Dictionary<string, double> ore = new Dictionary<string, double>();
    Random random = new Random();
    private void AddOre(string Name, double Value)
    {
        ore.Add(Name, 1.0 / Value);
    }
    
    private string GetOreType()
    {
        double probSum = 0;
        double rand = random.NextDouble();
        foreach (var pair in ore)
        {
            probSum += pair.Value;
            if (probSum > rand)
            {
                return pair.Key;
            }
        }
        return "Normal Ore";
    }
    
    private void Action()
    {
        AddOre("Cobalt", 20);
        AddOre("Stone", 10);
        AddOre("Iron", 100);
        AddOre("GreenOre", 300);
    
            //Add Common ore and sort Dictionary
            AddOre("Common ore", 1 / (1 - ore.Values.Sum()));
            ore = ore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Console.WriteLine(GetOreType());
    }
