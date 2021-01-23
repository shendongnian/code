    if (sc >= 0 && sc <= 89395)
    {
        var results = new List<float>(1143600); // Specify number of items upfront for better performance
        for (int z = 0; z <= 1143600; z++)
        {
            results.Add(dotproduct(sc, z)); // is a function to multiply to float
        }
        var index = 1;
        foreach(var result in results.OrderByDescending(x => x))
        {
            System.Console.WriteLine(String.Format("{0}: {1}", index++, result));
        }
    }
