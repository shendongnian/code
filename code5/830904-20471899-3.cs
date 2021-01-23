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
    const int THRESHOLD = 1000;
    static List<Double> pointsA = new List<double>();
    static List<Double> pointsB = new List<double>();
    private static void Method1()
    {
        var startTime = DateTime.Now;
        HashSet<double> hash = new HashSet<double>(pointsA);
        hash.IntersectWith(pointsB);
        if (hash.Count >= THRESHOLD)
        {
            var endTime = DateTime.Now;
            Console.WriteLine("HashSet: " + (endTime - startTime).TotalSeconds);
        }
        else
        {
            var endTime = DateTime.Now;
            Console.WriteLine("HashSet: " + (endTime - startTime).TotalSeconds);
        }
    }
    private static void Method2()
    {
        var startTime = DateTime.Now;
        if (pointsA.Where(pointsB.Contains).Skip(THRESHOLD - 1).Any())
        {
            var endTime = DateTime.Now;
            Console.WriteLine("Linq: " + (endTime - startTime).TotalSeconds);
        }
        else
        {
            var endTime = DateTime.Now;
            Console.WriteLine("Linq: " + (endTime - startTime).TotalSeconds);
        }
    }
    private static void Method3()
    {
        var startTime = DateTime.Now;
        int numberOfSharedPoints = pointsA.Count(pointsB.Contains);
        if (numberOfSharedPoints >= THRESHOLD)
        {
            var endTime = DateTime.Now;
            Console.WriteLine("Given: " + (endTime - startTime).TotalSeconds);
        }
        else
        {
            var endTime = DateTime.Now;
            Console.WriteLine("Given: " + (endTime - startTime).TotalSeconds);
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
            if (pointsB.Contains(d)) intersectItemCount++;
            if (intersectItemCount > THRESHOLD)
            {
                endTime = DateTime.Now;
                Console.WriteLine("Traditional: " + (endTime - startTime).TotalSeconds);
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
