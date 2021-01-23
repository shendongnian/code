    public static IList<Tuple<T,T>> GetPairs<T>(IList<T> list)    
    {
        IList<Tuple<T,T>> res = new List<Tuple<T,T>>();
        for (int i = 0; i < list.Count(); i++)
        {
            for (int j = i + 1; j < list.Count(); j++)
            {
                res.Add(new Tuple<T, T>(list[i], list[j]));
            }
        }
        return res;
    }
