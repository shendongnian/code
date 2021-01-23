    private IDictionary<int, string> GetCompanies(int coid)
    {
        var result = MemoryCache.Default[coid.ToString()] as IDictionary<int, string>;
        if (result != null)
        {
            // we already have cached results => no need to perform expensive database calls
            // we can return directly the cached results;
            return result;
        }
    
        // there's nothing in the cache => we need to make the DB call
        // and cache the results for subsequent use
        using (var dc = new CompanyViewModelDbContext())
        {
            result =
                (from cr in db.CompanyRelationship
                 //This is grabbing all related companies to the logged in user
                 join c in db.Companies on cr.CoId equals c.CoId
                 where cr.PartnerCoId == coid
                 select new
                 {
                     cr.CoId,
                     c.CompanyName
                 }).Distinct().ToDictionary(cr => cr.CoId, c => c.CompanyName);
        }
    
        var policy = new CacheItemPolicy
        {
            // Cache the results of the Db query for 24 hours
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(24),
            Priority = CacheItemPriority.NotRemovable,
        };
        
        MemoryCache.Default.Set(coid.ToString(), result, policy);
    
        return result;
    }
