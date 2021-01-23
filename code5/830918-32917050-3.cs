    public static Boolean CompareSS(IEnumerable<Int32> ss1, IEnumerable<Int32> ss2, Int32 threshold) 
    {
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
 
