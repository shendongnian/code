    bool loadNumerics = true;
    bool loadAlphas  = true;
    bool loadComplex = true;
    
    var query = from basics in ctx.Basics
                select new HodgePodge
                {
                   Basics = basics,
                   Numerics = ctx.Numerics.FirstOrDefault(x => loadNumerics == true && basics.ID == x.ItemID),
                   Alphas = ctx.Alphas.FirstOrDefault(x => loadAlphas == true && basics.ID == x.Itemid),
                   Complex = ctx.Complex.Where(x => loadComplex == true && basics.ID == x.Itemid),
                };
