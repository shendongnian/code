    bool loadNumerics = true;
    bool loadAlphas  = true;
    bool loadComplex = true;
    
    var query = from basics in ctx.Basics
                select new HodgePodge
                {
                   Basics = basics,
                   Numerics = loadNumerics ? ctx.Numerics.FirstOrDefault(x => basics.ID == x.ItemID) : null,
                   Alphas = loadAlphas  ? ctx.Alphas.FirstOrDefault(x => basics.ID == x.Itemid) : null,
                   Complex = loadNumerics ? ctx.Complex.Where(x => basics.ID == x.Itemid) : null,
                };
