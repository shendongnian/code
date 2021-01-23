    protected void Dropdownlist1_Changed(object sender, EventArgs, e)
    {
    	string item = Dropdownlist1.SelectedValue;
    	if(item == "State 1")
    	{
    		Panel1.Visible = false;
    		Panel2.Visible = true;
    	}
    }
