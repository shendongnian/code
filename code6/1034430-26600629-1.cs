    private static readonly List<int> TheList = 
        new List<int> { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5 };
    public static void Main(string[] args)
    {
        Expression<Func<int, bool>> initialQuery = x => x != 5;
        IEnumerable<int> result = GetAll(initialQuery);
        foreach (int i in result)
        {
            Console.WriteLine(i);
        }
        Console.ReadLine();
    }
