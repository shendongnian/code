    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Latitude.Text = thisPlace.Latitude;
        }
    }
