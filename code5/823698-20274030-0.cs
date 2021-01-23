    protected SitesRepository GetRepository()
    {
        if (db == null)
        {
            db = new UnitOfWork().SitesRepository;
        }
        return db;
    }
