    var magic = new MagicClass();
    data = data.Where(magic.MyWhere<DAL.TradeCard,int>(it => it.IsSomething && it.Name != "some name"));
    if(!Cache.HasKey(magic.Hash))
        Cache[magic.Hash] = data.ToList();
    return Cache[magic.Hash];
   
