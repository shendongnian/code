    protected void Page_Load(OBject sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            IdText.Value = "Example";
        }
    }
