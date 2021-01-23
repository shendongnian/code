    IEnumerable<Item> rpo = (from ro in _db.rpo.Where(c=> c.Id == WorkingId))
                             select new Items 
                             {
                               ItemId = ro.Id
                               ItemDescription = ro.Description
                               ItemNum = ro.Number
                               ItemStatus = ro.Status ?? Status.None
                             }.ToList();
