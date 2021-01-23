    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // other code
            txtDescription.Text = description;
        }
    }
