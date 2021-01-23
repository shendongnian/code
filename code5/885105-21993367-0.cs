    // GET api/companies
    public IQueryable<Company> GetCompanies()
    {
        return _session.Query<Company>();
    }
