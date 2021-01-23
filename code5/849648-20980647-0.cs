    DataSet ds = new DataSet();
    DataTable dt = new DataTable("Table1");
    ds.Tables.Add(dt);
    ds.Load(read, LoadOption.PreserveChanges, ds.Tables[0]);
    gridControl1.DataSource = ds.Tables[0];
