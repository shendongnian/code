    var ore = new Dictionary<string, double>();
    private void AddOre(string Name, int Value)
    {
        ore.Add(Name, (double)1 / Value * 1000);
    }
    
    private string GetOreType()
    {
        double probSum = 0;
        double rand = GetRandomNumber(0, 1000);
        //Console.WriteLine("Prob: "+rand);
        foreach (var pair in ore)
        {
            probSum += (double)pair.Value;
            // Console.Write(probSum+"("+pair.Key+", "+pair.Value+"), ");
            if (probSum >= rand)
            {
                return pair.Key;
            }
        }
        return "Normal Ore";
    }
    
    public double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random(Convert.ToInt32(DateTime.Now.Ticks.ToString().Substring(0, 8)));
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
    
    private void Action()
    {
        AddOre("Cobalt", 20);
        AddOre("Stone", 10);
        AddOre("Iron", 100);
        AddOre("GreenOre", 300);
    
        Console.WriteLine(GetOreType());
    }
