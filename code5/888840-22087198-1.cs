    dt = (DataTable)Session["datatable"];
    if (dt.Rows.Count >= 0 && grdView.SelectedIndex != -1)
    {
        dt.Rows[grdView.SelectedIndex]["Column1"] = TxtName.Text;
        dt.Rows[grdView.SelectedIndex]["Column2"] = txtAge.Text;
        grdView.DataSource = dt;
        grdView.DataBind();
     }
