    DataTable tbldata = new DataTable();
    tbldata.Columns.Add("ID", typeof(int));
    tbldata.Columns.Add("PrID", typeof(int));
    tbldata.Columns.Add("Name", typeof(string));
    tbldata.Rows.Add(1, null, "N1");
    tbldata.Rows.Add(2, 1, "N2");
    tbldata.Rows.Add(3, 2, "N3");
    tbldata.Rows.Add(4, 3, "N4");
