    public void Override(AutoMapping<SillyNameParent> mapping)
    {
        ...
        mapping.HasMany(x => x.Children)
            .Cascade.All()
            .KeyColumn("SillyNameParentId")
            .Inverse() // this is the way how to manage insertions
            .Not
            .LazyLoad();   
