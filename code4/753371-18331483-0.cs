    private TimeReport paramTR;
    private ZevUser zevUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.getParameters();
        if (!this.IsPostBack)
        {
            if ((this.paramTR != null) &&
                (this.paramTR.ZevUser != null) &&
                (this.paramTR.ZevUser.Active == 0))
            {
                this.Response.Redirect("~/TimeReporting/TimeReportPanel.aspx");
            }
            this.bindData();
        }
        string sessionId = Session["SessionId"] as string;
        if (sessionId != null)
        {
            int session = int32.Parse(sessionId);
            ZevUser user = ZevUser.GetById(session);
            if (user == null)
            {
                this.Response.Redirect("~/About.aspx");
            }
        }
    }
