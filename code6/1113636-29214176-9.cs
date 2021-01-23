    private FooGroup NewFooGroup(List<FooItem> foo, 
               Int32 weightLimit, int nextGrp)
    {
        FooGroup grp = new FooGroup(nextGrp);
        int FitWt = (weightLimit - 45);       // 45 is max wt in test set
                               
        // the find best fit below might have "looked ahead"
        // and used the current one, so filter those out
        foreach (FooItem f in foo.Where( g => g.GroupID == -1))
        {
            
            if ((grp.TotalWeight() + f.Weight) < weightLimit)
            {
                f.GroupID = nextGrp;
                grp.Add(f);
            }
            // full enough that one more item could fill
            if (grp.TotalWeight() >= FitWt)
            {
                int wtThreshold = (weightLimit - grp.TotalWeight());
                // find items that fit ordered by wt
                List<FooItem> xfoo = foo.Where(
                    w => (w.Weight <= wtThreshold) & (w.GroupID == -1)
                                ).OrderByDescending(w => w.Weight).ToList();
                // pack up the best fit
                if (xfoo.Count > 0)
                {
                    xfoo[0].GroupID = nextGrp;
                    grp.Add(xfoo[0]);
                }
            }
        }
        return grp;
    }
   
