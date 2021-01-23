    var myRpt2 = (
            dtPoints.AsEnumerable()
            .AsQueryable()
            .GroupBy("new ( it[\"Point_Date\"] as GrpByCol1)", "it")
            as IEnumerable<IGrouping<DynamicClass,DataRow>>
        )
        .Select (r => new { ((dynamic)r.Key).GrpByCol1, 
                            Sum = r.Sum(x => x.Field<decimal>("Point_Value0"))});
