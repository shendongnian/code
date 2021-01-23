    CalendarService service;
    static string gFolder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = GetClientConfiguration().Secrets,
                DataStore = new FileDataStore(gFolder),
                Scopes = new[] { CalendarService.Scope.Calendar }
            });
    
        var uri = Request.Url.ToString();
        var code = Request["code"];
        if (code != null)
        {
            var token = flow.ExchangeCodeForTokenAsync(UserId, code,
                uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;
    
            // Extract the right state.
            var oauthState = AuthWebUtility.ExtracRedirectFromState(
                flow.DataStore, UserId, Request["state"]).Result;
            Response.Redirect(oauthState);
        }
        else
        {
            var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId,
                CancellationToken.None).Result;
            if (result.RedirectUri != null)
            {
                // Redirect the user to the authorization server.
                Response.Redirect(result.RedirectUri);
            }
            else
            {
                // The data store contains the user credential, so the user has been already authenticated.
                service = new CalendarService(new BaseClientService.Initializer
                {
                    ApplicationName = "Calendar API Sample",
                    HttpClientInitializer = result.Credential
                });
            }
        }
    
    }
    
    public static GoogleClientSecrets GetClientConfiguration()
    {
        using (var stream = new FileStream(gFolder + @"\client_secrets.json", FileMode.Open, FileAccess.Read))
        {
            return GoogleClientSecrets.Load(stream);
        }
    }
