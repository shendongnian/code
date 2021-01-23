    public static IEnumerable<Tuple<T, int>> RunningTotal(this IEnumerable<T> source)
    {
        var counter = new Dictionary<T, int>();
        foreach(var s in source)
        {
            if(counter.ContainsKey(s))
            {
                counter[s]++;
            }
            else
            {
                counter.Add(s, 1);
            }
 
            yield return new Tuple(s, couter[s]);
        }
    }
