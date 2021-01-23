    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var data = ... // code that retrieves the data here
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
