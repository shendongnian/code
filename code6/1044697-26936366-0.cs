    public static IList<T> TakeRandom(this IEnumerable<T> source, int count, Random random)
    {
        var list = new List<T>(count);
        int i = 0;
        foreach (var item in source)
        {
            if (list.Count < count)
            {
                list.Add(item);
            }
            else
            {
                int j = random.Next(i + 1);
                if (j < k)
                {
                    list[j] = item;
                }
            }
            i++;
        }
        return list;
    }
