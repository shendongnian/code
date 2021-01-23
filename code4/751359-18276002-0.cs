    public Cv3AddressDao ReadSingle<TEntity>(Expression<Func<TEntity, bool>> predicate)
    {
        // ...
    }
    ...
    var dao = new MyDao();
    var addr = dao.ReadSingle<MyEntity>(x => x.SiteId == 1);
