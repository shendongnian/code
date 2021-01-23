    BarMap
    {
        Table("Bars");
        Reference(x => x.Foo).Column("FooId");
        HasOne(x => x.Bar).PropertyRef(x => x.Bar).Not.Lazy.Cascade.SaveUpdates();
    }
    
    BazMap
    {
        Table("Baz");
        Reference(x => x.Foo).Column("BarId");
    }
