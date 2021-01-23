    protected void Page_Load(object sender, EventArgs e)
    {
        CancelUnexpectedRePost();
    }
 
    private void CancelUnexpectedRePost()
    {
        string clientCode = _repostcheckcode.Value;
 
        //Get Server Code from session (Or Empty if null)
        string serverCode = Session["_repostcheckcode"] as string  ?? "";
 
        if (!IsPostBack || clientCode.Equals(serverCode))
        {
            //Codes are equals - The action was initiated by the user
            //Save new code (Can use simple counter instead Guid)
            string code = Guid.NewGuid().ToString();  
            _repostcheckcode.Value = code;
            Session["_repostcheckcode"] = code;
        }
        else
        {
            //Unexpected action - caused by F5 (Refresh) button
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
