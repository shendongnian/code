    public override void DoSomething(ICollection features)
    {
        var grp = features.OfType<MyBaseClass>().GroupBy(x => x.table);
        foreach(var g in grp) base.DoSomething((ICollection)g.ToList());
    }
