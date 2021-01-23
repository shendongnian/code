    public static IEnumerable<Tuple<T, int>> RunningTotal<T>(this IEnumerable<T> source)
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
 
            yield return Tuple.Create(s, counter[s]);
        }
    }
