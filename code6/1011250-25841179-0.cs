    public void startUpRoleControl()
    {
    	loadRoleControl();
    	disableAllToolStripItems();
    	
    	if (dtDBRoleControl.Rows.Count > 0)
    	{				
    		for (int i = 0; i < menuStrip1.Items.Count; i++ ) //menuStrip1 is the main menu strip which holds the menu items.
    		{
    			foreach(DataRow drmaster in dtDBRoleControl.Rows)
    			{
    				ProcessDropDown(menuStrip1.Items[i], drmaster["rprevformname"].ToString(), Convert.ToInt32(drmaster["rprevview"]) );
    			}
    		}
    	}
    }
    
    private void ProcessDropDown(ToolStripItem item, string rprevformname, int rprevview)
    {
    	ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
    	if (!menuItem.HasDropDownItems)
    		return;
    	else
    	{
    		foreach (ToolStripMenuItem val in menuItem.DropDownItems)
    		{
    			if (val.HasDropDownItems)
    				ProcessDropDown(val, rprevformname, rprevview);
    			if (val.Tag != null && val.Tag.ToString() == rprevformname, && rprevview == 1)
    			{
    				val.Visible = false;
    				menuItem.Visible = false;
    			}
    		}
    	}
    }
