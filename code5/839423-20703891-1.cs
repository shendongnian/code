    int i = 0;
    protected void rpMyRepeater1_ItemDataBound(object Sender, RepeaterItemEventArgs e)
    {
    	// if the item on repeater is a item of data
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
    	{
    		// get value
    		string value = DataBinder.Eval(e.Item.DataItem, "CotisationMensuelle").ToString();
    		
    		// find literal
    		Literal ltl = (Literal)e.Item.FindControl("ltl");
    		
    		// check if i < 2
    		if (i < 2)
    		{
    			// write value
    			ltl.Text = value;
    			//increase i
    			i++;
    		}
    		else 
    		{
    			// write value and <br/>
    			ltl.Text = string.Format("{0}<br />", value);
    			
    			// zero i
    			i = 0;
    		}
    	}
    }
