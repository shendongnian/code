    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            yourUserControl.TextApplied += new YourUserControl.TextAppliedEventHandler(yourUserControl_TextApplied)
        }
    }
