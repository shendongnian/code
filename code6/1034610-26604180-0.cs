    if (e.Row.RowType == DataControlRowType.DataRow)
    {
       HyperLink HLWebsite = (HyperLink) e.Row.FindControl("HLWebsite");
       DataRowView rowView = (DataRowView)e.Row.DataItem;
       HLWebsite.NavigateURL = rowView["Website"].ToString(); 
    
    }
