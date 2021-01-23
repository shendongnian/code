    foreach(Control c in flp_AddNewThings.Controls)
    {
    	if(c is TextBox)
    	{
    		db.Save(c.Text);
    	}
    	...
    }
