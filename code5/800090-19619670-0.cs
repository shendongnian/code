    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSource = GetData();
            Repeater1.DataBind();
        }
    }
