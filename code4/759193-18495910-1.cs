    protected void create_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            // Only deal with data rows, not header or footer rows, etc.
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                HiddenField poid = ((HiddenField)gvr.FindControl("poid"));
                // Check if hidden field was found or not
                if(poid != null)
                {
                    if (((HtmlInputCheckBox)gvr.FindControl(poid.Value)).Checked)
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
    }
