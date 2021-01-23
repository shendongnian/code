    var query = from r1 in dt1.AsEnumerable()
                join r2 in dt2.AsEnumerable()
                on r1.Field<string>("TEST2")
                equals string.Format("{0}-{1}-{2}"
                        , r2.Field<string>("TEST2")
                        , r2.Field<string>("TEST5")
                        , r2.Field<string>("TEST6"))
                select new { r1, r2 };
    foreach (var bothRows in query)
    {
        DataRow addedRow = dt.Rows.Add();
        addedRow.SetField("TEST2", bothRows.r1.Field<string>("TEST2"));
        addedRow.SetField("TEST3", bothRows.r2.Field<string>("TEST3"));
        addedRow.SetField("TEST7", bothRows.r2.Field<string>("TEST7"));
    }
