    static void Main(string[] args)
    {
        int i = 0;
        Random r = new Random();
        while (i < 10000)
        {
            pointsA.Add(r.NextDouble());
            i++;
        }
        i = 0;
        while (i < 10000)
        {
            pointsB.Add(r.NextDouble());
            i++;
        }
        Method1();
        Method2();
        Method3();
        Method4();
    }
    const int THRESHOLD = 100;
    static List<Double> pointsA = new List<double>();
    static List<Double> pointsB = new List<double>();
    private static void Method1()
    {
        var startTime = DateTime.Now;
        HashSet<double> hash = new HashSet<double>(pointsA);
        hash.IntersectWith(pointsB);
        var endTime = DateTime.Now;
        Console.WriteLine("HashSet: " + (endTime - startTime).TotalSeconds);
        if (hash.Count >= THRESHOLD)
        {
        }
    }
    private static void Method2()
    {
        var startTime = DateTime.Now;
        pointsA.Where(pointsB.Contains).Skip(THRESHOLD - 1);
        var endTime = DateTime.Now;
        Console.WriteLine("Linq: " + (endTime - startTime).TotalSeconds);
        if (pointsA.Where(pointsB.Contains).Skip(THRESHOLD - 1).Any())
        {
            Console.WriteLine("Threshold reached.");
        }
    }
    private static void Method3()
    {
        var startTime = DateTime.Now;
        int numberOfSharedPoints = pointsA.Count(pointsB.Contains);
        var endTime = DateTime.Now;
        Console.WriteLine("Given: " + (endTime - startTime).TotalSeconds);
        if (numberOfSharedPoints >= THRESHOLD)
        {
            Console.WriteLine("Threshold reached.");
        }
    }
    private static void Method4()
    {
        var startTime = DateTime.Now;
        var intersectItemCount = 0;
        var endTime = DateTime.Now;
        bool thresholdReached = false;
        foreach (var d in pointsA)
        {
            pointsB.Contains(d);
            intersectItemCount++;
            if (intersectItemCount > THRESHOLD)
            {
                endTime = DateTime.Now;
                Console.WriteLine("Traditional: " + (endTime - startTime).TotalSeconds);
                Console.WriteLine("Threshold reached.");
                thresholdReached = true;
                break;
            }
        }
        if (!thresholdReached)
        {
            endTime = DateTime.Now;
            Console.WriteLine("Traditional: " + (endTime - startTime).TotalSeconds);
        }
    }
