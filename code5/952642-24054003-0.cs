    Get Solution using aspsnippets.facebookapi.dll. 
    protected void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key = "<Your API KEY>";
        FaceBookConnect.API_Secret = "<Your API SECRET>";
        if (!IsPostBack)
        {
            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                ViewState["Code"] = code;
                pnlPost.Enabled = true;
                btnAuthorize.Enabled = false;
            }
        }
    }
    protected void Authorize(object sender, EventArgs e)
    {
        FaceBookConnect.Authorize("publish_actions", Request.Url.AbsoluteUri);
    }
    protected void Post(object sender, EventArgs e)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("link", "http://www.aspsnippets.com");
        data.Add("picture", "http://www.aspsnippets.com/images/Blue/Logo.png");
        data.Add("caption", "ASP Snippets");
        data.Add("name", "ASP Snippets");
        data.Add("message", "I like ASP Snippets");
        FaceBookConnect.Post(ViewState["Code"].ToString(), "me/feed", data);
    }
