    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var data = new List<int> { 1, 2, 3, 4, 5 };
            DemoGrid.DataSource = data;
            DemoGrid.DataBind();
        }
    }
