    static IEnumerable<Tuple<string, int>> FindAdjacentItems(IEnumerable<string> list)
    {
        string previous = null;
        int count = 0;
        foreach (string item in list)
        {
            if (previous == item)
            {
                count++;
            }
            else
            {
                if (count > 1)
                {
                    yield return Tuple.Create(previous, count);
                }
                count = 1;
            }
            previous = item;
        }
        
        if (count > 1)
        {
            yield return Tuple.Create(previous, count);
        }
    }
