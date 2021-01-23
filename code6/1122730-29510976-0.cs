    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (hdnEventId.Value != "" && hdnEventId.Value != "0")
            {
                LoadEvent();
            }
        }
    }
