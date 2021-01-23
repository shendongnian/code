    protected void Page_Load(object sender, EventArgs e)
    {
        object obj = Session["oom-user"];
        if (obj is UserOOM)
        {
            Response.Write("logged in");
        }
        else
        {
            Response.Write("not logged in");
        }
    }
