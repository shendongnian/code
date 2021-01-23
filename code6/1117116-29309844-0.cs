    protected void Page_Load(object sender, EventArgs e)
    {
        gs = ConfigurationManager.ConnectionStrings["ging"].ConnectionString;
        if (Master.showCheck(s))
        {
            //do something...
        }
    }
