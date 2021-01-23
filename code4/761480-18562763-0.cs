    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            visitAgain.Visible = true;
            visitAgain.NavigateUrl = Request.Url.AbsolutePath + "?Id" + x;
        }
    }
