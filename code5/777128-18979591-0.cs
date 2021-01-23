	private int controlCount
	{
		get 
		{
			int val = 0;
			try
			{
				val = (int)Page.ViewState["ControlCount"];
			}
			catch(Exception e)
			{
				// handle exception, if required.
			}
			return val;
		}
		set { Page.ViewState["ControlCount"] = value; }
	}
	protected void addnewtext_Click(object sender, EventArgs e)
	{
		int i = controlCount++;
	    for (int j = 0; j <= i; j++)
	    {
	        AddVisaControl ac = (AddVisaControl)Page.LoadControl("AddVisaControl.ascx");
	        placeHolder.Controls.Add(ac);
	        placeHolder.Controls.Add(new LiteralControl("<BR>"));
	    }
	}
