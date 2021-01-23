    protected void Page_Load(..)
    {
    	if(GetControlThatCausedPostBack(this).Equals(btnId)
    	{
    		...
    		if (Page.IsPostBack)
    		  {
    		   ...
    		  }
    	}
    }
