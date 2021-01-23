    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DataBindGridView(); // method that assigns DataSource and calls DataBind
        }
    }
