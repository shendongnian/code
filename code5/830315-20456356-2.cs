    public Option? UniqueOption()
    {
        var distinct = optionList.Distinct(x=> x.Option);
        if(distinct.Count() == 1)
        {
            return distinct.First().Option;
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
