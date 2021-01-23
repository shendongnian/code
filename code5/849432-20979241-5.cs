    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            yourUserControl.TextApplied += new EventHandler(yourUserControl_TextApplied)
        }
    }
