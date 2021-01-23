    private void rdoEnableCntType_Checked(object sender, EventArgs e)
    {
    	if (rdoEnableCntType.Checked = true)
    	{
    		FrmConentType frm = new FrmConentType();		
    		frm.ShowDialog();
    		List<string> list = frm.SelectedItems;
    		//Place your code to use selected items
    	}
    }
