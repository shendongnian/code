    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Resource");
        dt.Columns.Add("available");
        foreach(GridViewRow row in grd.Rows)
        {
            dr = dt.NewRow();
            dr["Resource"] = row.Cells[0].Text;
            dr["available"] =row.Cells[1].Text;
            dt.Rows.Add(dr);
        }
        dr = dt.NewRow(); 
        dr["Resource"] = ddlResource.SelectedItem.Text;
        dr["available"] = txtavailable.Text;
        dt.Rows.Add(dr);
        grd.DataSource = dt;
        grd.DataBind();
    }
