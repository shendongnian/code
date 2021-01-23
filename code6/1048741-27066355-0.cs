    DataTable dtResult = new DataTable();
    var query = from row1 in dt1.AsEnumerable()
                join row2 in dt2.AsEnumerable() on
                    new { ID = row1.Field<int>("ID"), Date = row1.Field<DateTime>("Date") }
                    equals
                    new { ID = row2.Field<int>("ID"), Date = row2.Field<DateTime>("Date") }
                select dtResult.LoadDataRow(new object[]
        {
            row1.Field<int>("ID"),
            row1.Field<DateTime>("Date"),
            row1.Field<double>("ValueA"),
            row1.Field<double>("ValueB"),
            row2.Field<double>("ValueC"),
            row2.Field<double>("ValueD")
        }, false);
