      static bool ListEquals(List<int> L1, List<int> L2)
    {
        if (L1.Count != L2.Count)
            return false;
        return L1.Except(L2).Count() == 0;
    }            
        /*
        if it is ok to change List content you may try
        L1.Sort();
        L2.Sort();
        return L1.SequenceEqual(L2);
        */
    static bool DictEquals(Dictionary<string, List<int>> D1, Dictionary<string, List<int>> D2)
    {
        if (D1.Count != D2.Count)
            return false;
        return D1.Keys.All(k => D2.ContainsKey(k) && ListEquals(D1[k],D2[k]));
            
    }
