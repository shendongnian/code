    static void ArrayTests()
    {
        // Item array lengths.
        for (int i = 45; i < 256; i++)
        {
            var items = Enumerable.Range(0, i).Select(x => x.ToString()).ToArray();
    
            // Number of tests per array.
            for (int j = 0; j < 100; j++)
            {
                // Items to remove.
                Random rnd = new Random(DateTime.Now.Millisecond);
                var remove = new int[rnd.Next(1, i)];
                HashSet<int> indexes = new HashSet<int>();
                for (int k = 0; k < remove.Length; k++)
                {
                    int index = 0;
                    do
                    {
                        index = rnd.Next(0, i);
                    } while (indexes.Contains(index));
                    indexes.Add(index);
                    remove[k] = index;
                }
                remove = remove.OrderBy(x => x).ToArray();
                var result = ArrayTest(items, remove);
            }
        }
    }
    
    static string[] ArrayTest(string[] items, int[] remove)
    {
        var A3 = new string[items.Length];
    
        int m = 0;
        int leftItemCount = items.Length - remove.Length;
        for (int i = 0, j = 0, k = 0, l = leftItemCount; i < leftItemCount || m < items.Length; i++)
        {
            m++;
            if (j < remove.Length && k == remove[j])
            {
                j++;
                k++;
                A3[l++] = "_";
                i--;
                continue;
            }
            A3[i] = items[k];
            k++;
        }            
        Debug.Assert(m == items.Length);
        return A3;
    }
