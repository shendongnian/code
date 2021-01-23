    private void BindData()
    {
    	if (innerControl != null)
    	{
    		//here, how??
    		Repeater repeater = innerControl.FindControl("repeater") as Repeater;
    		if (repeater != null)
    		{
    			repeater.DataSource = JobContext.GetEngagementLetterReport(SPContext.Current.Site, true, 500, 1);
    			repeater.DataBind();
    		}
    	}
    }
