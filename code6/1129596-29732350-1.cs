    public static void Main(string[] args)
    {
        var runs = 1000; //Run the code this many times
        var sb = new StringBuilder(); //To test, it will add to a string builder
        //Create list
        var list = new List<int>();
        for (var i = 0; i < 50000; i++)
            list.Add(i);
        //Try Count() each iteration
        var stopwatch = Stopwatch.StartNew();
        for (var x = 0; x < runs; x++)
        {
            for (var i = 0; i < list.Count(); i++)
                sb.Append(list[i]); //Just give it something to do
            sb.Clear();
        }
        Console.WriteLine("Count() each iteration, {0}ms", stopwatch.ElapsedMilliseconds);
        //Try Count() once
        stopwatch.Restart();
        for (var x = 0; x < runs; x++)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++)
                sb.Append(list[i]);
            sb.Clear();
        }
        Console.WriteLine("Count() once, {0}ms", stopwatch.ElapsedMilliseconds);
        Console.ReadLine();
    }
