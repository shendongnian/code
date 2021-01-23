    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // assign 'type' query string to typeOfSearch
            string typeOfSearch = Request.QueryString["type"];
        }
    }
