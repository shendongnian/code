    DataTable dt = new DataTable();
    dt.Columns.Add("Foo", typeof (DateTime));
    dt.Rows.Add(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Unspecified));
    dt.Rows.Add(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Local));
    dt.Rows.Add(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc));
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    string xml = ds.GetXml();
    Debug.Write(xml);
