    public virtual IQueryable<MyEntity> GetQueryable()
    {
        var session = ....
        return sesion.query<MyEntity>();
    }
