    protected void Page_Load(object sender, EventArgs e)
    {
        // Default sign value that may be changed by value in session cache
        String sign = "";
        // Is there a session value for theSign
        if(Session["theSign"] != null)
        {
            // Yes, so set the sign variable value to use in click event handlers
            sign = Session["theSign"].ToString();
        }
    }
