    static bool IsSubsetWithDuplicates<T>(IEnumerable<T> superset, IEnumerable<T> subset)
    {
        var supersetLookup = superset.ToLookup(a => a);
        foreach (var subsetGroup in subset.ToLookup(a => a))
        {
            if(subsetGroup.Count() > supersetLookup[subsetGroup.Key].Count())
            {
                return false;
            }
        }
    
        return true;
    }
