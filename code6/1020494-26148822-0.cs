    (
        from h in MyContext.HistoryItems
        where h.UserId == userId)
        group h by new { 
                            h.CompanyId, 
                            Comapany = h.Company.Name, 
                            Prospectus = h.Prospectus.Name, 
                            h.Prospectus.Online, 
                            h.ProsId 
                       } into grp
        select new { 
                        Max = grp.Max(i => i.Id),
                        grp.Key.CompanyId,
                        grp.Key.Comapany,
                        grp.Key.Prospectus,
                        grp.Key.Online,
                        grp.Key.ProsId,
                   } into proj
        orderby proj.Max descending
        select proj
    ).Distinct().Take(10)
