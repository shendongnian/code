    newtable2 = ADataTable.AsEnumerable().GroupBy(a => new
    {
        PLANT = a.Field<int>("PLANT"),
        PDCATYPE_NAME = a.Field<int>("PDCATYPE_NAME"),
        Month = a.Field<int>("Month"),
        Year = a.Field<int>("Year"),
        STATUS_NAME_REPORT = a.Field<string>("STATUS_NAME_REPORT")
    }).Select(g =>
    {
        var row = newtable2.NewRow();
        row.ItemArray = new object[]
                {
                    g.Key.PLANT, 
                    g.Key.PDCATYPE_NAME,
                    g.Key.Month,
                    g.Key.Year,
                    g.Key.STATUS_NAME_REPORT,
                    g.Sum(r => r.Field<double>("SAVINGS_PER_MONTH"))
                };
        return row;
    }).CopyToDataTable();
