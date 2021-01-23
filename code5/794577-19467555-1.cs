    GridView grdview = (GridView)item.FindControl("GridView1");
    DataTable dt = new DataTable();
    dt.Columns.Add("Columnname");
    DataRow dr = dt.NewRow();
    dr["Columnname"] = "hello";
    dt.Rows.Add(dr);
    grdView.DataSource = dt;
    grdView.DataBind();
