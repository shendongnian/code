    var ore = new Dictionary<string, double>();
    var random = new Random();
    private void AddOre(string Name, double Value)
    {
        ore.Add(Name, 1.0 / Value);
    }
    
    private string GetOreType()
    {
        double probSum = 0;
        double rand = random.NextDouble();
        //Console.WriteLine("Prob: "+rand);
        foreach (var pair in ore)
        {
            probSum += pair.Value;
            // Console.Write(probSum+"("+pair.Key+", "+pair.Value+"), ");
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
    
        Console.WriteLine(GetOreType());
    }
