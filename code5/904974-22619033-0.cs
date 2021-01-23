    var r = from grp in Groups
            join da in GroupSettings on grp.GroupID equals da.GroupID into ga // direct 
            join db in GroupSettings on grp.BzId equals db.GroupID into gb // Busisness
            join dc in GroupSettings on grp.PartnerId equals dc.GroupID into gc // Partner
            from gar in ga.DefaultIfEmpty()
            from gbr in gb.DefaultIfEmpty()
            from gcr in gc.DefaultIfEmpty()
            where grp.GroupID == 29
            select new { setting = gar ?? gbr ?? gcr };  // null coalesce
