    var q = (from a in _context.tblTradeSpends.AsEnumerable()
        where a.VersionDate < DateTime.Parse("6/1/2013")        
        select new
        {
            DealPeriod = a.DealPeriod,
            CustomerNumber = a.CustomerNumber,
            LOB = a.LOB,
            PromoID = a.PromoID,
            VersionDate = a.VersionDate
        }).Distinct(new MyComparer()).OrderBy(o => o.DealPeriod)
                                     .ThenByDescending(o => o.CustomerNumber)
                                     .ThenByDescending(o => o.LOB)
                                     .ThenByDescending(o => o.PromoID).ToList();
