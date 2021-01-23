     protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        //Put your code in here. This will only load the first time the page loads.
        bindDrEmail();
        }
    }
