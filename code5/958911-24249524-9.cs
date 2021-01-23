    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = (LinkButton )e.Row.Cells[0].Controls[0];
            if (lb != null)
                lb.Attributes.Add("onClick", "javascript:return changevalue(this);");
        }
    }
