    var distinctUnitNumber = dsUnits.Tables[0].AsEnumerable()
        .Select(r => r.Field<int>("UnitNumber"))
        .Concat(dsUnits.Tables[1].AsEnumerable()
           .Select(r => r.Field<int>("UnitNumber")))
        .Distinct();
