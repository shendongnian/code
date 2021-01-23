    protected void Page_Load(object sender, EvemtArgs e)
    {
        if(!Page.IsPostBack)
        {
            string yourURL = "SOME URL?USER=" + Session["username"].ToString();
            dg.Columns[0].DataNavigateUrlFormatString = yourURL;
        }
    }
