    var query = ADataTable.AsEnumerable()
        .GroupBy(row => new
        {
            PLANT = row.Field<int>("PLANT"),
            PDCATYPE_NAME = row.Field<int>("PDCATYPE_NAME"),
            Month = row.Field<int>("Month"),
            Year = row.Field<int>("Year"),
            STATUS_NAME_REPORT = row.Field<string>("STATUS_NAME_REPORT")
        });
    foreach (var g in query)
    {
        newtable.LoadDataRow(new object[]
        {
                     g.Key.PLANT,
                     g.Key.PDCATYPE_NAME,
                     g.Key.Month,
                     g.Key.Year,
                     g.Key.STATUS_NAME_REPORT,
                    g.Sum(savings => savings.Field<double>("SAVINGS_PER_MONTH"))
        }, LoadOption.OverwriteChanges);
    }
