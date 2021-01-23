        query = query.Include(entity => entity.T.C);
        query = query.Include(entity => entity.TC.Select(tc => tc.T.M));
        query = query.Include(entity => entity.TC);
        query = query.Include(entity => entity.W.FW.F.S);
        query = query.Include(entity => entity.W.FW.P);
        query = query.Include(entity => entity.W.PL.P);
        query = query.Include(entity => entity.W.PL);
        query = query.Include(entity => entity.W.E);
        query = query.Include(entity => entity.E);
     
        query = query.Where( set of conditions );
        List<BaseTable> Loaded = query.ToList();
    }
