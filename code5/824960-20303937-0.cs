    static void Main(string[] args)
    {
        var tuple = GetItem()
        Console.WriteLine(string.Format("Item1: {0}", tuple.Item1));
        Console.WriteLine(string.Format("Item2: {0}", tuple.Item2));
    }
    public static Tuple<string, int> GetItem()
    {
        return new Tuple<string, int>("Some item from database.", 4);
    }
