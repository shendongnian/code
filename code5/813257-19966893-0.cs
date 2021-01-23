    [HttpPost]
    public ICollection<AppAccount> Service(ODataQueryOptions opts)
    {
        var results = opts.ApplyTo(db.AppAccounts.Where(aa => aa.AppAccountClass.Name == "Service")) as IQueryable<AppAccount>;
        if (results != null) return results.ToList();
        throw new HttpResponseException(HttpStatusCode.BadRequest);
    }
