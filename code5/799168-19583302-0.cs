    DataRow[] drnew = dt.Select("Price <> 0");
    DataRow[] drzero = dt.Select("Price = 0");
    DataTable dtfinal = new DataTable();
    if (drnew != null && drnew.Count() > 0)
    {
        DataView dv = drnew.CopyToDataTable().DefaultView;
        dv.Sort = "Price Desc";
        dtfinal = dv.Table;
    }
    if (drzero != null && drzero.Count() > 0)
    {
        dtfinal.Merge(drzero.CopyToDataTable());
    }
