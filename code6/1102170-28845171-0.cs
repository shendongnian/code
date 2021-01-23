    public static void Main()
    {
        var text = File.ReadAllText("d:\\public\\temp\\temp.txt");
        int wordCount;
        var sw = new Stopwatch();
        sw.Start();
        wordCount = text.Split(null).Length;
        sw.Stop();
        Console.WriteLine("Detected {0} words in {1} ticks.", wordCount, sw.ElapsedTicks);
        sw.Restart();
        wordCount = text.Count(Char.IsWhiteSpace);
        sw.Stop();
        Console.WriteLine("Detected {0} words in {1} ticks.", wordCount, sw.ElapsedTicks);
        sw.Restart();
        wordCount = text.AsParallel().Count(Char.IsWhiteSpace);
        sw.Stop();
        Console.WriteLine("Detected {0} words in {1} ticks.", wordCount, sw.ElapsedTicks);
    }
