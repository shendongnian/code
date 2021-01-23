    public IEnumerable<foobar> GetFooBarInfo(int intFooID)
    {
        foo f = null;
        bar b = null;
        baz bz = null;
        foobar fb = null;
    
        return db.QueryOver<foo>(() => f)
                 .Where(fi => fi.otherentity.fooid == intFooID)
                 .Inner.JoinQueryOver(bb => bb.baz, () => bz)
                 .Inner.JoinQueryOver(ba => ba.bar, () => b)
                 .Inner.JoinQueryOver(fbar => fbar.foobar, () => fb)
                 .Select(Projections.ProjectionList()
                          .Add(Projections.Property(() => fb.barid), "barid")
                          .Add(Projections.Property(() => fb.barname), "barname")
                          .Add(Projections.Property(() => fb.bardescription), "bardescription")
                 )
                 .TransformUsing(Transformers.AliasToBean<foobar>())
                 .List<foobar>();
    }
