    protected void Page_Load(Object sender, EventArgs e)
    {
    	var input = Request.QueryString["input"];
    
    	if (!string.IsNullOrEmpty(input))
    	{
    		litResult.Text = input;
    	}
    }
