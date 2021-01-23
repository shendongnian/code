        ToolStripMenuItem menuItem = item as ToolStripMenuItem; //Type casting from ToolStripItem to     ToolStripMenuItem
        if (!menuitem) //This I have not tested, but it should work for you to test whether it was able to type cast
            return;
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
