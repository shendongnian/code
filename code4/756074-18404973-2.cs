    public void GetInterestRates(string listKey, out decimal currentRate, out decimal previousRate)
    {
        var q = context.Istc0.Include("Interests").Where(a => a.IIsin == listKey).Select(a => new
            {
                Istc0 = a,
                Interests = a.Interests.Where(d => d.InDat >= date)
            }).ToList();
        
        
        var currentRate = q[0].Istc0;
        var previousRate = q.OrderByDescending(d => d.InDat).Take(1).SingleOrDefault().Istc0;
    
    }
