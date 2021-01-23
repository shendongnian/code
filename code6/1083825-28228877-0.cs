    public DaoLeave
    {
        // Properties of DaoLeave, same as properties of LEAVE
        internal void DaoLeave(LEAVE doLeave)
        {
            // set properties from properties ... alternately, use something like AutoMapper
        }
    }
    public IQueryable<DaoLeave> getLeaves()
    {
        dbContext db = new dbContext;
        return db.LEAVEs.Select(l => new DaoLeave(l));
    }
