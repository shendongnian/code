    static void Main(string[] args)
    {
        var o = Enumerable.Range(0, 100).Select(x => x.ToString());
        int i = 0;
        var groups = o.GroupBy(x => i++ / 3);
        foreach (var g in groups)
        {
            Console.WriteLine(String.Join(",", g));
        }
    }
