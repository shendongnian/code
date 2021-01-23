    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strStatus = Request.QueryString["status"];
            DListStatus.SelectedValue = strStatus;
        }
    }
