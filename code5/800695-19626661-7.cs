    private static void Main()
    {
        var files = new[]{"File1.txt", "File2.txt", "File3.txt"};
        var tasks = files.Select(f => Task.Factory.StartNew(() => ReadIntFromFile(f)));
        Task.WaitAll(tasks.ToArray());
        Console.Write("Sum: {0}", result);
        Console.ReadLine();
    }
