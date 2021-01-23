    Please use following query:
        
    
     var foodViewsList = (from t in fooditems
                             join r in ratings on t.itemid equals r.itemid
                             group r by new { r.itemid, t.itemname, t.itemprice } into g
                             select new FoodView
                             {
                                 itemid = g.Key.itemid,
                                 itemname = g.Key.itemname,
                                 itemprice = g.Key.itemprice,
                                 vote = g.Sum(x => x.vote)
                             }).ToList();
