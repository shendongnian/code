    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PageOpened"] != null) 
        {
            // The page is already opened in another tab.
        }
        else { Session["PageOpened"] = true; }
    }
