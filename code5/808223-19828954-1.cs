    public static IEnumerable<T> Cached<T>(IEnumerable<T> enumerable)
    {
        var cache = new List<T>();
        var enumerator = enumerable.GetEnumerator();
            
        return Generate(()    => { return new int[1]; },
                        (pos) => {
                            pos[0] += 1;
                            if (pos[0] < cache.Count())
                            {
                                return new Tuple<T>(cache[pos[0]]);
                            }
                            if (enumerator.MoveNext())
                            {
                                cache.Add(enumerator.Current);
                                return new Tuple<T>(enumerator.Current);
                            }
                            return null;
                        });
    }
