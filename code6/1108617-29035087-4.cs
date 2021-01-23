    var uniqueUnits = new HashSet<Unit.Unit>(new Unit.UnitComparer());
    foreach (DataRow row in dsUnits.Tables[0].Rows)
    {
        Unit.Unit unit = new Unit.Unit
        {
            UnitNum = row["UnitNumber"].NullSafeToString(),
            CustCode = row["CustCode"].NullSafeToString(),
            Year = row["Year"].NullSafeToString(),
            Make = row["Make"].NullSafeToString(),
            Model = row["Model"].NullSafeToString()
        };
        uniqueUnits.Add(unit);
    }
    foreach (DataRow row in dsUnits.Tables[1].Rows)
    {
        Unit.Unit unit = new Unit.Unit
        {
            UnitNum = row["UnitNumber"].NullSafeToString()
        };
        uniqueUnits.Add(unit);
    }
