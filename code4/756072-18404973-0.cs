    var q = context.Istc0.Include("Interests").Where(a => a.IIsin == listKey).Select(a => new
        {
            Istc0 = a,
            Interests = a.Interests.Where(d => d.InDat >= date)
        }).ToList();
    
    
        var xxx = q[0].Istc0;
        var yyy = q.OrderByDescending(d => d.InDat).Take(1).SingleOrDefault().Istc0;
