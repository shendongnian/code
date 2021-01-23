    IEnumerable<int> FindAll(IEnumerable<int> source, Predicate<int> predicate)
    {
        List<int> result = new List<int>();
        foreach (int item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
