    static void Main(string[] args)
    {
        double totalTimeSpentIntersectAndSkip = 0;
        double totalTimeSpentHashSet = 0;
        double totalTimeSpentCount = 0;
        double totalTimeSpentWhereAndSkip = 0;
        double totalTimeSpentForEach = 0;
        int maxIteration = 5;
        for (int j = 0; j < maxIteration; j++)
        {
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                pointsA.Add(r.NextDouble());
            }
            for (int i = 0; i < 10000; i++)
            {
                pointsB.Add(r.NextDouble());
            }
            s.Reset(); s.Start();
            var timeSpentInSeconds = TestUsingIntersectAndSkip();
            s.Stop();
            Console.WriteLine("IntersectAndSkip: " + timeSpentInSeconds);
            totalTimeSpentIntersectAndSkip += timeSpentInSeconds;
            s.Reset(); s.Start();
            timeSpentInSeconds = TestUsingHashSet();
            s.Stop();
            Console.WriteLine("HashSet: " + timeSpentInSeconds);
            totalTimeSpentHashSet += timeSpentInSeconds;
            s.Reset(); s.Start();
            timeSpentInSeconds = TestUsingForEach();
            s.Stop();
            Console.WriteLine("ForEach: " + timeSpentInSeconds);
            totalTimeSpentForEach += timeSpentInSeconds;
            s.Reset(); s.Start();
            timeSpentInSeconds = TestUsingWhereAndSkip();
            s.Stop();
            Console.WriteLine("WhereAndSkip: " + timeSpentInSeconds);
            totalTimeSpentWhereAndSkip += timeSpentInSeconds;
            s.Reset(); s.Start();
            timeSpentInSeconds = TestUsingCount();
            s.Stop();
            Console.WriteLine("Count: " + timeSpentInSeconds);
            totalTimeSpentCount += timeSpentInSeconds;
            Console.WriteLine("-------------------------------------------------------------------------------");
            GC.Collect();
            System.Threading.Thread.Sleep(2000);
        }
        Console.WriteLine("Following is Average TimeSpent by each method: "+Environment.NewLine);
        Console.WriteLine("IntersectAndSkip: " + totalTimeSpentIntersectAndSkip / maxIteration);
        Console.WriteLine("HashSet: " + totalTimeSpentHashSet / maxIteration);
        Console.WriteLine("ForEach: " + totalTimeSpentForEach / maxIteration);
        Console.WriteLine("WhereAndSkip: " + totalTimeSpentWhereAndSkip / maxIteration);
        Console.WriteLine("Count: " + totalTimeSpentCount / maxIteration);
        Console.WriteLine("-------------------------------------------------------------------------------");
    }
    static Stopwatch s = new Stopwatch();
    const int THRESHOLD = 100;
    static List<Double> pointsA = new List<double>();
    static List<Double> pointsB = new List<double>();
    private static double TestUsingHashSet()
    {
        HashSet<double> hash = new HashSet<double>(pointsA);
        hash.IntersectWith(pointsB);
        if (hash.Count >= THRESHOLD)
        {
            return s.Elapsed.TotalSeconds;
        }
        else
        {
            return s.Elapsed.TotalSeconds;
        }
    }
    private static double TestUsingWhereAndSkip()
    {
        if (pointsA.Where(pointsB.Contains).Skip(THRESHOLD - 1).Any())
        {
            return s.Elapsed.TotalSeconds;
        }
        else
        {
            return s.Elapsed.TotalSeconds;
        }
    }
    private static double TestUsingCount()
    {
        int numberOfSharedPoints = pointsA.Count(pointsB.Contains);
        if (numberOfSharedPoints >= THRESHOLD)
        {
            return s.Elapsed.TotalSeconds;
        }
        else
        {
            return s.Elapsed.TotalSeconds;
        }
    }
    private static double TestUsingForEach()
    {
        var intersectItemCount = 0;
        foreach (var d in pointsA)
        {
            if (pointsB.Contains(d)) intersectItemCount++;
            if (intersectItemCount > THRESHOLD)
            {
                return s.Elapsed.TotalSeconds;
            }
        }
        return s.Elapsed.TotalSeconds;
    }
    private static double TestUsingIntersectAndSkip()
    {
        if (pointsA.Intersect(pointsB).Skip(THRESHOLD - 1).Any())
        {
            return s.Elapsed.TotalSeconds;
        }
        else
        {
            return s.Elapsed.TotalSeconds;
        }
    }
