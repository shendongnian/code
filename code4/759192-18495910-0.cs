    protected void create_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            // Only deal with data rows, not header or footer rows, etc.
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                HiddenField poid = ((HiddenField)gvr.Cells[0].FindControl("poid"));
                if (((HtmlInputCheckBox)gvr.FindControl(poid.Value)).Checked == true)
                {
                    Response.Redirect("ShipmentDetail.aspx?id=" + poid.Value);
                }
                else
                {
                    //Do nothing
                }
            }
        }
    }
