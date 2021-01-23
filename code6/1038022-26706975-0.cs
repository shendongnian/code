    private Dictionary<string, Cashiers> dict = new Dictionary<string, Cashiers>();
    private void Save(string name, [probably some other details?])
    {
        dict[name] = new Cashiers(); // or whatever
    }
    private void Print(string name)
    {
        Console.WriteLine(dict[name]);
    }
    private void PrintAll()
    {
        Console.WriteLine(string.Join(Environment.NewLine, dict.Select(c => c.Key + "\t" + c.Value.ToString()));
    }
