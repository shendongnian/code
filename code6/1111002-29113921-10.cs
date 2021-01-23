    DataTable dt = new DataTable();
    dt.Columns.Add("Foo", typeof(DateTimeOffset));
    dt.Rows.Add(new DateTimeOffset(2015, 1, 1, 0, 0, 0, TimeSpan.FromHours(11)));
    dt.Rows.Add(new DateTimeOffset(2015, 1, 1, 0, 0, 0, TimeSpan.Zero));
    dt.Rows.Add(new DateTimeOffset(2015, 1, 1, 0, 0, 0, TimeSpan.FromHours(-3)));
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    string xml = ds.GetXml();
    Debug.Write(xml);
