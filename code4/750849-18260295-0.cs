    static List<int> list = new List<int> { 1, 2, 3 };
    static IEnumerable<int> result = from i in list where i > 2 select i;
    static void Main(string[] args)
    {
        Console.WriteLine(result.Sum()); // 3
        list.Add(5);
        Console.WriteLine(result.Sum()); // 8
    }
