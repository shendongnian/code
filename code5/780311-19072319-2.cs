    protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var message = (Share.Service.Message)e.Row.DataItem;
            var lblRecipientsCount = (Label)e.Row.FindControl("lblRecipientsCount");
            lblRecipientsCount.Text = message.Recipients.Count();
            lblRecipientsCount.ToolTip = string.Join(",", message.Recipients.Select(rec => rec.Name));
        }
    }
