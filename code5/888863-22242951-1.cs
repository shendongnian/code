    protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e))
    {
    	RadComboBox RadComboBox1 = (RadComboBox)sender;
    	
    	// Get the placeholder control nested inside the RadGrid
    	Placeholder plupload = (Placeholder)FindControlRecursive(RadGrid1, "plupload");
    	
    	if (plupload != null)
    	{
    		if (RadComboBox1.SelectedValue == "2")
    			plupload.Visible = false;
    		else plupload.Visible = true;
    	}
    }
