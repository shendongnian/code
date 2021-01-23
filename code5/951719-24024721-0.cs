    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.AsyncPostBackSourceElementID.EndsWith("imgBtn"))
        {
            Repeater.DataSource = someList;
            Repeater.DataBind();
        }
    }
