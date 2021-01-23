    var dt1 = new DataTable();
    dt1.Columns.Add("Column A", typeof (string));
    dt1.Columns.Add("Column B", typeof (string));
    dt1.Columns.Add("Column C", typeof (int));
    dt1.Rows.Add("XYZ", "s54a4", 1);
    dt1.Rows.Add("QWE", "g743s", 2);
    dt1.Rows.Add("ABC", "j74ss", 2);
    var dt2 = new DataTable();
    dt2.Columns.Add("Column A", typeof (string));
    dt2.Columns.Add("Column C", typeof (int));
    dt2.Columns.Add("Column Z", typeof (string));
    dt2.Rows.Add("XYZ", 1, "something1");
    dt2.Rows.Add("QWE", 2, "something2");
    dt2.Rows.Add("ABC", 4, "something3");
    var dt3 = new DataTable();
    dt3.Columns.Add("Column A", typeof (string));
    dt3.Columns.Add("Column C", typeof (int));
    dt3.Columns.Add("Column Z", typeof (string));
    dt3.Columns.Add("Column B", typeof (string));
    // Assumes value in Column A in dt1 is unique
    // Joins on Column A between the two tables then filters where column C isn't the same
    var data = from dataRow1 in dt1.AsEnumerable()
               join dataRow2 in dt2.AsEnumerable() on dataRow1.Field<string>("Column A") equals
                   dataRow2.Field<string>("Column A")
               where dataRow1.Field<int>("Column C") != dataRow2.Field<int>("Column C")
               select
                   new[]
                       {dataRow2["Column A"], dataRow2["Column C"], dataRow2["Column Z"], dataRow1["Column B"]};
    // add the results into dt3
    foreach (var d in data)
    {
        dt3.Rows.Add(d);
    }
