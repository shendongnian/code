    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Repeater1.DataSource = listOfData;
            Repeater1.DataBind();            
        }
        // Repeater1.DataBind(); // and tried to put DataBind() here
    }
