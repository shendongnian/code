    public static IEnumerable<IEnumerable<T>> PowerSets<T>(this IList<T> set)
    {
        var totalSets = BigInteger.Pow(2, set.Count);
        for (BigInteger i = 0; i < totalSets; i++)
        {
            yield return set.SubSet(i);
        }
    }
    public static IEnumerable<T> SubSet<T>(this IList<T> set, BigInteger n)
    {
        for (int i = 0; i < set.Count && n > 0; i++)
        {
            if ((n & 1) == 1)
            {
                yield return set[i];
            }
            n = n >> 1;
        }
    }
