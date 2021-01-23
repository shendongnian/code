    var unitsFrom1 = dsUnits.Tables[0].AsEnumerable()
        .Select(row => new Unit.Unit
        {
            UnitNum = row["UnitNumber"].NullSafeToString(),
            CustCode = row["CustCode"].NullSafeToString(),
            Year = row["Year"].NullSafeToString(),
            Make = row["Make"].NullSafeToString(),
            Model = row["Model"].NullSafeToString()
        });
    
    var unitsFrom2Notin1 = 
        from row in dsUnits.Tables[1].AsEnumerable()
        join u1 in unitsFrom1
        on row.Field<string>("UnitNumber") equals u1.UnitNum into outer
        from outerJoin in outer.DefaultIfEmpty()
        where outerJoin == null
        select new Unit.Unit
        {
            UnitNum = row["UnitNumber"].NullSafeToString()
        };
               
