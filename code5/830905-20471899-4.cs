    static void Main(string[] args)
    {
        int i = 0;
        Random r = new Random();
        while (i < 50000)
        {
            pointsA.Add(r.NextDouble());
            i++;
        }
        i = 0;
        while (i < 50000)
        {
            pointsB.Add(r.NextDouble());
            i++;
        }
        TestUsingCollectionIntersectMethod();
        TestUsingHashSet();
        TestUsingForEach();
        TestUsingCollectionCountMethod();
        TestUsingLinqWhereAndSkip();
    }
    static Stopwatch s = new Stopwatch();
    const int THRESHOLD = 1000;
    static List<Double> pointsA = new List<double>();
    static List<Double> pointsB = new List<double>();
    private static void TestUsingHashSet()
    {
        s.Reset(); s.Start();
        HashSet<double> hash = new HashSet<double>(pointsA);
        hash.IntersectWith(pointsB);
        if (hash.Count >= THRESHOLD)
        {
            s.Stop();
            Console.WriteLine("HashSet: " + s.Elapsed.TotalSeconds);
        }
        else
        {
            s.Stop();
            Console.WriteLine("HashSet: " + s.Elapsed.TotalSeconds);
        }
    }
    private static void TestUsingLinqWhereAndSkip()
    {
        s.Reset(); s.Start();
        if (pointsA.Where(pointsB.Contains).Skip(THRESHOLD - 1).Any())
        {
            s.Stop();
            Console.WriteLine("Linq: " + s.Elapsed.TotalSeconds);
        }
        else
        {
            s.Stop();
            Console.WriteLine("Linq: " + s.Elapsed.TotalSeconds);
        }
    }
    private static void TestUsingCollectionCountMethod()
    {
        s.Reset(); s.Start();
        int numberOfSharedPoints = pointsA.Count(pointsB.Contains);
        if (numberOfSharedPoints >= THRESHOLD)
        {
            s.Stop();
            Console.WriteLine("Given: " + s.Elapsed.TotalSeconds);
        }
        else
        {
            s.Stop();
            Console.WriteLine("Given: " + s.Elapsed.TotalSeconds);
        }
    }
    private static void TestUsingForEach()
    {
        s.Reset(); s.Start();
        var intersectItemCount = 0;
        bool thresholdReached = false;
        foreach (var d in pointsA)
        {
            if (pointsB.Contains(d)) intersectItemCount++;
            if (intersectItemCount > THRESHOLD)
            {
                s.Stop();
                Console.WriteLine("Traditional: " + s.Elapsed.TotalSeconds);
                thresholdReached = true;
                break;
            }
        }
        if (!thresholdReached)
        {
            s.Stop();
            Console.WriteLine("Traditional: " + s.Elapsed.TotalSeconds);
        }
    }
    private static void TestUsingCollectionIntersectMethod()
    {
        s.Reset(); s.Start();
        if (pointsA.Intersect(pointsB).Skip(THRESHOLD - 1).Any())
        {
            s.Stop();
            Console.WriteLine("Intersect: " + s.Elapsed.TotalSeconds);
        }
        else
        {
            s.Stop();
            Console.WriteLine("Intersect: " + s.Elapsed.TotalSeconds);
        }
    }
