    public Option? UniqueOption()
    {
        var distinct = optionList.Select(x=> x.Option).Distinct();
        if(distinct.Count() == 1)
        {
            return distinct.First();
        }
        return null;
    }
    public Option? UniqueOptionOptimized()
    {
        HashSet<Option> set = new HashSet<Option>();
        foreach (var item in optionList)
        {
            if (set.Add(item.Option) && set.Count > 1)
            {
                return null;
            }
        }
        if (set.Count == 1)
            return set.First();
        else
            return null;
    }
    public Option? UniqueOptionOptimized2()
    {
        using(var distinctEnumerator = optionList.Select(x => x.Option).Distinct().GetEnumerator())
        {
            if(distinctEnumerator.MoveNext())
            {
                var firstOption = distinctEnumerator.Current.Option;
                if(!distinctEnumerator.MoveNext())
                    return firstOption;
            }
        }
        return null;
    }
