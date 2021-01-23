    protected void btn3_Click(object sender, EventArgs e)
    {
    	lbltext.Visible = false;
    	if (lstBoxAreaOfResponsibility2.Items.Count != 0)
    	{
    		lstBoxAreaOfResponsibility2.Items.Clear();
    	}
    	else
    	{
    		lbltext.Visible = true;
    		lbltext.Text = "There Is No Item To Move";
    	}
    }
    
    protected void btn4_Click(object sender, EventArgs e)
    {
    	lbltext.Visible = false;
    	if (lstBoxAreaOfResponsibility2.SelectedIndex >= 0)
    	{
    		ListItem itemToDelete = new ListItem();
    		foreach (ListItem Item in lstBoxAreaOfResponsibility2.Items)
    		{
    			if (Item.Selected == true)
    			{
    				itemToDelete = Item;
    			}
    		}
    		lstBoxAreaOfResponsibility2.Items.Remove(itemToDelete);
    	}
    	else
    	{
    		lbltext.Visible = true;
    		lbltext.Text = "Please select atleast one in Listbox2 to move";
    	}
    }
