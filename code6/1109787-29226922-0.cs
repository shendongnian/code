    protected void Page_Load(object sender, EventArgs e)
    {
        //XRDS request handling that solves the yadis discovery problem
        if (Request.AcceptTypes.Any(a => a.Contains("xrds")))
        {
            Response.Clear();
            Response.ContentType = "application/xrds+xml";
            string path = Server.MapPath(Request.ApplicationPath + "/Content/yadis.xml");
            logger.Info(string.Format("yadis path: {0}", path));
            Response.WriteFile(path);
            Response.End();
            return;
        }
        if (!IsPostBack)
        {
            OpenIdRelyingParty openId = new OpenIdRelyingParty();
    
            IAuthenticationResponse response = openId.GetResponse();
            ValidateLogin(response);
    
            if (response == null || response.Status != AuthenticationStatus.Authenticated)
            {
                logger.Info("Not logged in.");
                Login(openId); //<-- this is why yadis discovery failed.
            }
    
        }
    }
