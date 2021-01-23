    static void Main(string[] args)
    {
        int size = 10000000;
        int[] ar = new int[size];
        //random number init with numbers [0,size-1]
        var r = new Random();
        for (var i = 0; i < size; i++)
        {
            ar[i] = r.Next(0, size);
            //ar[i] = i; // Test 2 -> uncomment to see the effects of caching more clearly
        }
        Console.WriteLine("Fixed dictionary:");
        for (var numBuckets = 10; numBuckets <= 1000000; numBuckets *= 10)
        {
            var num = (size / numBuckets);
            var timing = 0L;
            for (var i = 0; i < 5; i++)
            {
                timing += FixBucketTest(ar, num);
                //timing += FixArrayTest(ar, num); // test 1
            }
            var avg = ((float)timing) / 5.0f;
            Console.WriteLine("Avg Time: " + avg + " ms for " + numBuckets);
        }
        Console.WriteLine("Fixed array:");
        for (var numBuckets = 10; numBuckets <= 1000000; numBuckets *= 10)
        {
            var num = (size / numBuckets);
            var timing = 0L;
            for (var i = 0; i < 5; i++)
            {
                timing += FixArrayTest(ar, num); // test 1
            }
            var avg = ((float)timing) / 5.0f;
            Console.WriteLine("Avg Time: " + avg + " ms for " + numBuckets);
        }
    }
    static long FixBucketTest(int[] ar, int num)
    {
        // This test shows that timings will not grow for the smaller numbers of buckets if you don't have to re-allocate
        System.Diagnostics.Stopwatch s = new Stopwatch();
        s.Start();
        var grouping = new Dictionary<int, List<int>>(ar.Length / num + 1); // exactly the right size
        foreach (var item in ar)
        {
            int idx = item / num;
            List<int> ll;
            if (!grouping.TryGetValue(idx, out ll))
            {
                grouping.Add(idx, ll = new List<int>());
            }
            //ll.Add(item); //-> this would complete a 'grouper'; however, we don't want the overallocator of List to kick in
        }
        s.Stop();
        return s.ElapsedMilliseconds;
    }
    // Test with arrays
    static long FixArrayTest(int[] ar, int num)
    {
        System.Diagnostics.Stopwatch s = new Stopwatch();
        s.Start();
        int[] buf = new int[(ar.Length / num + 1) * 10];
        foreach (var item in ar)
        {
            int code = (item & 0x7FFFFFFF) % buf.Length;
            buf[code]++;
        }
        s.Stop();
        return s.ElapsedMilliseconds;
    }
