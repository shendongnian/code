    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hl= (HyperLink)e.Row.findControl("HyperLink2");   
                hl.NavigateUrl = "Your Url";
            }
        }
