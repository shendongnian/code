    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostback)
        {
            Repeater1.DataSource = SomeDataSource; // whatever
            Repeater1.DataBind();
        }
    }
