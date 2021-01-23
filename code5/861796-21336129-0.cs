    private void initcontrol()
    {
    	String str_name = "name";
    	String str_value = "value";
    	var result = false;
    	foreach(Form f in getformular())
    	{
    		//if you want to check if f null, it should be here.
    		if(f != null) result = setControlText(f, str_name, str_value);
    	}
    	if(!result) MessageBox.Show("Control not found");
    }
    
    private bool setControlText(Control control, string str_name, string str_value)
    {
    	var isSuccess = false;
    	foreach (Control c in control.Controls)
    	{
    		//if c is not null
    		if (c != null)
    		{
    			//check c's Tag, if not null and matched str_name set the text
    			if (c.Tag != null && c.Tag.Equals(str_name))
    			{
    				c.Text = str_value;
    				isSuccess = true;
    			}
    			//else, search in c.Controls
    			else isSuccess = setControlText(c, str_name, str_value);
    
    			//if control already found and set, exit the method now
    			if (isSuccess) return true;
    		}
    	}
    	return isSuccess;
    }
 
