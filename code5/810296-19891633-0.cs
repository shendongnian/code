    protected void Page_Load(object sender, EventArgs e)
    {
         Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    	
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
      ... now this works
    }
