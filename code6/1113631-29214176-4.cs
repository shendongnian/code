    private IEnumerable<List<FooItem>> GetFooGroups(List<FooItem> foo, Int32 weightLimit)
    {
        List<FooItem> unGrouped = foo.Where(g => (g.Grouped == false)).ToList();
        // ToDo: tweak conditions to fit real world needs
        while ((unGrouped.Count >3) && (unGrouped.Sum( w => w.Weight) > weightLimit))
        {
            yield return NewFooGroup(unGrouped, weightLimit);
            unGrouped = foo.Where(g => (g.Grouped == false)).ToList();
        }     
    }
    private List<FooItem> NewFooGroup(List<FooItem> foo, Int32 weightLimit)
    {
        List<FooItem> grp = new List<FooItem>();
        int total = 0;
        foreach (FooItem f in foo)
        {
            if ((grp.Sum(w => w.Weight) + f.Weight < weightLimit))
            {
                total += f.Weight;
                f.Grouped = true;
                grp.Add(f);
            }
            // ToDo: make the threshold a property, global or param
            if (total >= (weightLimit * .95))
                break;
        }
        return grp;
    }
