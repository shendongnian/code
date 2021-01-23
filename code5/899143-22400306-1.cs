    static void Main(string[] args)
    {
        const  int testCount = 10000000;
        var stopWatch = new Stopwatch();
        int a = 2456;
        int b = 2456;
        stopWatch.Start();
        for (int i = 0; i < testCount; i++)
        {
            CopyIfDifferent(ref a, b);
        }
        stopWatch.Stop();
        Console.WriteLine("int equal CopyIfDifferent {0}", stopWatch.ElapsedMilliseconds);
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            a = b;
        }
        stopWatch.Stop();
        Console.WriteLine("int equal assignment {0}", stopWatch.ElapsedMilliseconds);
        string c = "dfsgdgdfg";
        string d = "dfsgdgdfg";
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            CopyIfDifferent(ref c, d);
        }
        stopWatch.Stop();
        Console.WriteLine("string equal CopyIfDifferent {0}", stopWatch.ElapsedMilliseconds);
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            c = d;
        }
        stopWatch.Stop();
        Console.WriteLine("string equal assignment {0}", stopWatch.ElapsedMilliseconds);
        int e = 2456;
        int f = 3465464;
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            CopyIfDifferent(ref e, f);
        }
        stopWatch.Stop();
        Console.WriteLine("int different CopyIfDifferent {0}", stopWatch.ElapsedMilliseconds);
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            e = f;
        }
        stopWatch.Stop();
        Console.WriteLine("int different assignment {0}", stopWatch.ElapsedMilliseconds);
        string g = "dfsgdgdfg";
        string h = "gdfhfghfghfghf";
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            CopyIfDifferent(ref g, h);
        }
        stopWatch.Stop();
        Console.WriteLine("string different CopyIfDifferent {0}", stopWatch.ElapsedMilliseconds);
        stopWatch.Restart();
        for (int i = 0; i < testCount; i++)
        {
            g = h;
        }
        stopWatch.Stop();
        Console.WriteLine("string different assignment {0}", stopWatch.ElapsedMilliseconds);
        Console.ReadLine();
    }
    public static void CopyIfDifferent(ref string vValueToCopyTo, string vValueToCopyFrom)
    {
        if (!ValuesAreEqual(vValueToCopyTo, vValueToCopyFrom))
        {
            vValueToCopyTo = vValueToCopyFrom;
        }
    }
    public static void CopyIfDifferent(ref int vValueToCopyTo, int vValueToCopyFrom)
    {
        if (vValueToCopyTo!= vValueToCopyFrom)
        {
            vValueToCopyTo = vValueToCopyFrom;
        }
    }
    public static bool ValuesAreEqual(string vValue1, string vValue2)
    {
        if (vValue1 == null && vValue2 == null)
        {
            return true;
        }
        if (vValue1 == null || vValue2 == null)
        {
            return false;
        }
        return vValue1 == vValue2;
    }
