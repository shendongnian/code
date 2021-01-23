    var ds = new DataSet("MyDataSet");
    var dt = new DataTable("MyDataTable");
    dt.Columns.Add(new DataColumn("name", typeof(string)));
    dt.Columns.Add(new DataColumn("email", typeof(string)));
    dt.Columns.Add(new DataColumn("phone", typeof(string)));
    
    dt.Rows.Add("John","john@company.com","56765765");
    dt.Rows.Add("Tom","tom@company.com","8978987987");
    ds.Tables.Add(dt);
    AutoSqlBulkCopy(ds);
