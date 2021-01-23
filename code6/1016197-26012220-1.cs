    protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {   
        //Get data row view
        DataRowView dataRow = ((e.Row.DataItem)DataRowView);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        	var link = ((HyperLink)e.FindControl("Link"));
        	link.Text = "some text";
        	link.NavigateUrl = String.Format("{0}?id={1}", page, dataRow.ID);
        }
    }
