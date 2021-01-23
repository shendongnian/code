    public static bool HasDuplicateCount<T>(this IEnumerable<T> seq, int maxCount)
    {
        Dictionary<T, int> counts = new Dictionary<T, int>();
        bool maxDuplicateReached = false;
        foreach (T t in seq)
        {
            int count;
            if (counts.TryGetValue(t, out count))
                counts[t] = ++count;
            else
                counts.Add(t, 1);
            if (count == maxCount)
            {
                maxDuplicateReached = true;
                break;
            }
        }
        return maxDuplicateReached;
    }
