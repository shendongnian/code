    var g = from t in dVipArchive.AsEnumerable()
        group t by new {id = t["ID"], cust=t["Customer"]}
        into grp
        select new 
        {
            grp.Key.id,
            grp.Key.cust,
            maxV = grp.Max(z => z["Value"])
        };
