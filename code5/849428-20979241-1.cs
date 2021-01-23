    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            yourUserControl.ApplyTextClicked += new EventHandler(yourUserControl_ApplyTextClicked)
        }
    }
