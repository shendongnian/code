    if (Page.IsPostBack)
    {
        MyLnkButton.Text = "Login";
    }
    else
    {
    	if (Session["USRID"] != null)//I would change this to use HttpContext.Current.Session["USERID"] and initialize it in the OnSessionStart() event in the Global.asax file
    	{
    		lblWLC.Text = (string)Session["USRID"];                   
    		MyLnkButton.Text = "Logout";
    		Bind_GV();
    	}
    }
