    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Resource");
        dt.Columns.Add("available");
        for (int intCnt = 0; intCnt < grd.Rows.Count - 1; intCnt++)
        {
            if (grd.Rows[intCnt].RowType == DataControlRowType.DataRow)
            {
                dr = dt.NewRow();
                dr["Resource"] = grd.Rows[intCnt].Cells[0].toString();
                dr["available"] = grd.Rows[intCnt].Cells[1].toString();
                dt.Rows.Add(dr);
            }
        }
        dr = dt.NewRow(); 
        dr["Resource"] = ddlResource.SelectedItem.Text;
        dr["available"] = txtavailable.Text;
        dt.Rows.Add(dr);
        grd.DataSource = dt;
        grd.DataBind();
    }
