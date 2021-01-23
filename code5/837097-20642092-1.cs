    protected void Page_Load(object sender, EventArgs e)
    {
        // Only bind repeater initially, not every post back
        if (!IsPostBack)
        {
            Repeater1.DataSource = GetDataFromDatabase();
            Repeater1.DataBind();
        }
    }
