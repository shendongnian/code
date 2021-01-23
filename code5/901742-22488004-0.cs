     protected void grdViewCustomers_OnRowDataBound(object sender, GridViewRowEventArgs e)
        { 
            if (e.Row.RowType==DataControlRowType.DataRow)
    	{
    	LinkButton LinkbtnPOSId=(LinkButton)e.Row.FindControl("LinkbtnPOSId");
        Label LabelStatusPendingPOSId = (Label)e.Row.FindControl("LabelStatusPendingPOSId");
        Boolean boolStatus = LabelStatusPendingPOSId.Text == "Applied" ? true : false;
        //LinkbtnPOSId.Attributes.Add("onclick", "function CheckStatus('" + boolStatus.ToString() + "')");	 
        LinkbtnPOSId.Enabled = boolStatus;
    
    	}
        
        }
