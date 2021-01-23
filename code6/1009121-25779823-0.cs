    public GroupMap()
    {
        ...
        HasOne(x => x.GroupSummaryLevel)
            .Cascade.None()
            //.ForeignKey("AcctGroup")
            .PropertyRef(gsl => gsl.AcctGroup)
            ;
    }
    public GroupSummaryLevelMap()
    {
        ...
        //References(x => x.Parent).Column("ParentId");
        //HasMany(x => x.Children).Cascade.All().KeyColumn("ParentId");
        References(x => x.Parent, "AcctGroup");
    }
