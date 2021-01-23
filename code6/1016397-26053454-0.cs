    protected void BTNBookingReq_Click(Object sender, EventArgs e)
    {
    	Button btnSender = (Button)sender;
    	DataGridItem item = btnSender.NamingContainer as DataGridItem;
    	if (item != null)
    	{
    		TextBox TxtTotalCoLoaderFrom1 = item.FindControl("TxtTotalCoLoaderFrom1") as TextBox;
    		//Do your operation here
    	}
    
    }
