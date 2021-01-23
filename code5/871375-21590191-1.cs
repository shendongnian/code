    public static bool HasDuplicateCount<T>(this IEnumerable<T> seq, int maxCount)
    {
        Dictionary<T, int> counts = new Dictionary<T, int>();
        bool maxDuplicateReached = false;
        foreach (T t in seq)
        {
            int count;
            if (counts.TryGetValue(t, out count))
                ++count;
            else
                count = 1;
            if (count == maxCount)
            {
                maxDuplicateReached = true;
                break;
            }
            counts[t] = count;
        }
        return maxDuplicateReached;
    }
