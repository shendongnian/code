    public static IList<T> TakeRandom<T>(
        this IEnumerable<T> source, int count, Random random)
    {
        var list = new List<T>(count);
        int n = 1;
        foreach (var item in source)
        {
            if (list.Count < count)
            {
                list.Add(item);
            }
            else
            {
                int j = random.Next(n);
                if (j < count)
                {
                    list[j] = item;
                }
            }
            n++;
        }
        return list;
    }
