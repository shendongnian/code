    private static List<List<T>> GroupBy(List<T> pages, int groupSize)
    {
        var result = new List<List<T>>();
        List<T> l;
        for (int i=0; i < pages.Count; i++)
        {
            if (i%groupSize == 0)
            {
                l = new List<T>();
                result.Add(l);
            }
            l.Add(pages[i]);
        }
        return result;
    }
