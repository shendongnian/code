    IQueryable<HodgePodge> Query = ctx.Basics.Select(u => new HodgePodge(){ Basic = u }).AsQueryable();
            if(ConditionNumeric)
                Query = Query.Join(ctx.Numerics,
                    q => q.Basic.ID,
                    n => n.Itemid,
                    (q, n) => new HodgePodge(){ Basic = q.Basic, Numeric = n })
                .AsQueryable();
            if(ConditionAlpha)
                Query = Query.Join(ctx.Alphas,
                    q => q.Basic.ID,
                    a => a.Itemid,
                    (q, a) => new HodgePodge(){ Basic = q.Basic, Alpha = a })
                .AsQueryable();
            if(ConditionComplex)
                Query = Query.Join(ctx.Complex,
                    q => q.Basic.ID,
                    c => c.Itemid,
                    (q, c) => new HodgePodge(){ Basic = q.Basic, Complex = c })
                .AsQueryable();
            return Query.ToList();
