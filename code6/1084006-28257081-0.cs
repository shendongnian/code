    from entry in left.Union(right)
    select new
    {
        ...
    } into e
    group e by new 
               { 
                   e.Date.Year, 
                   Quartal = (e.Date.Month - 1) / 3 + 1, 
                   e.Date.Month, 
                   contract = e.Contract.extNo 
               } into grp
    select new
    {
        Year = grp.Key,
        Quartal = grp.Key,
        Month = grp.Key,
        Contracts = from x in grp
                    select new
                    {
                        ExtNo = month.Key,
                        Entries = contract,
                    }
    }
