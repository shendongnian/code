    int FromHere = 0;
    int TotalRows = gvRoute.Items.Count;
    DataTable dt = new DataTable();
    DataTable dtcache = (DataTable)Session["MyTable"];
    DataRow DRTransfer;
    foreach (DataColumn column in dtcache.Columns)
    {
        dt.Columns.Add(column.ColumnName, column.DataType);
    }
    for (int x = 0; x < TotalRows; x++)
    {
        FromHere = OurOrder[x];
        DRTransfer = dtcache.Rows[FromHere];
        dt.ImportRow(DRTransfer);
    }
    gvRoute.DataSourceID = "";
    gvRoute.DataSource = dt;
    gvRoute.DataBind();
