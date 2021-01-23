    dt = (DataTable)Session["datatable"];
    if (dt.Rows.Count >= 0)
    {
        dt.Rows[grdView.SelectedIndex]["Column1"] = TxtName.Text;
        dt.Rows[grdView.SelectedIndex]["Column1"] = txtAge.Text;
        grdView.DataSource = dt;
        grdView.DataBind();
     }
