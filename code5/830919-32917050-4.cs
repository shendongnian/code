    public static void TimeTest()
    {
        int size = 20000;
        List<Int32>ss1 = new List<int>(size);
        List<Int32>ss2 = new List<int>(size);
        for(int i = 0; i < size; i++)
        {
            Int32 int1 = i;
            Int32 int2 = i + (Int32)((float)size / 2);
            ss1.Add(i);
            ss2.Add(int2);
        }
        //foreach (int iTest in ss1)
        //    System.Diagnostics.Debug.WriteLine(iTest);
        //System.Diagnostics.Debug.WriteLine("");
        //foreach (int iTest in ss2)
        //    System.Diagnostics.Debug.WriteLine(iTest);
    
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        int thresHold1 = (Int32)((float)size / 4);
        int thresHold2 = (Int32)((float)size * 3 / 4);
    
        Int32 matchcount = 0;
        for(int i = 0; i <= size; i++)
        {
            if(CompareSS(ss1, ss2, thresHold1))
                matchcount++;
            if (CompareSS(ss1, ss2, thresHold2))
                matchcount++;
        }
        System.Diagnostics.Debug.WriteLine("sw.ms {0}   count {1}", sw.ElapsedMilliseconds.ToString("N0"), matchcount.ToString("N0"));
        sw.Restart();
        matchcount = 0;
        for (int i = 0; i <= size; i++)
        {
            if (ss1.Intersect(ss2).Skip(thresHold1 - 1).Any())
                matchcount++;
            if (ss1.Intersect(ss2).Skip(thresHold2 - 1).Any())
                matchcount++;
        }
        System.Diagnostics.Debug.WriteLine("sw.ms {0}   count {1}", sw.ElapsedMilliseconds.ToString("N0"), matchcount.ToString("N0"));
        sw.Stop();
    
    }
    public static bool CompareSS (IEnumerable<Int32> ss1, IEnumerable<Int32> ss2, Int32 threshold) 
    {
        //System.Diagnostics.Debug.WriteLine("threshold {0}", threshold);
        using (var cursor1 = ss1.GetEnumerator())
        using (var cursor2 = ss2.GetEnumerator())
        {
            if (!cursor1.MoveNext() || !cursor2.MoveNext())
            {
                return false;
            }
            Int32 int1 = cursor1.Current;
            Int32 int2 = cursor2.Current;               
            int count = 0;
            while (true)
            {
                //System.Diagnostics.Debug.WriteLine("int1 {0}   int2 {1}", int1, int2);
                int comparison = int1.CompareTo(int2);
                if (comparison < 0)
                {
                    if (!cursor1.MoveNext())
                    {
                        return false;
                    }
                    int1 = cursor1.Current;
                }
                else if (comparison > 0)
                {
                    if (!cursor2.MoveNext())
                    {
                        return false;
                    }
                    int2 = cursor2.Current;
                }
                else
                {
                    count++;
                    if (count >= threshold)
                        return true;
                    if (!cursor1.MoveNext() || !cursor2.MoveNext())
                        return false;
                    int1 = cursor1.Current;
                    int2 = cursor2.Current;
                }
            }
        }
    }
