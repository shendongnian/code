    private const string RedirectUrl = "https://www.facebook.com/connect/login_success.html";
    private static readonly IReadOnlyCollection<string> Permissions = new[] { "email", "offline_access" };
    protected override void OnActivated(IActivatedEventArgs args)
    {
        base.OnActivated(args);
        var continuationActivatedEventArgs = args as IContinuationActivatedEventArgs;
        if (continuationActivatedEventArgs == null)
            return;
        var webAuthenticationResult = ((WebAuthenticationBrokerContinuationEventArgs)continuationActivatedEventArgs).WebAuthenticationResult;
        if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
        {
            var facebookClient = new FacebookClient();
            var result = facebookClient.ParseOAuthCallbackUrl(new Uri(webAuthenticationResult.ResponseData));
            if (!result.IsSuccess)
            {
                // Process unsuccessful authentication
            }
            else
            {
                // Process successful authentication
                var accessToken = result.AccessToken;
            }
        }
    }
    
    // Authentication method, this method should be invoked when you click Facebook authentication button
    public void AuthenticateAndContinue()
    {
        var loginUrl = GetLoginUrl();
        WebAuthenticationBroker.AuthenticateAndContinue(loginUrl, new Uri(RedirectUrl));
    }
    private Uri GetLoginUrl()
    {
        var parameters = new Dictionary<string, object>();
        parameters["client_id"] = "YourFacebookApplicationId";
        parameters["redirect_uri"] = RedirectUrl;
        parameters["response_type"] = "token";
        parameters["display"] = "touch";
        parameters["mobile"] = true;
        parameters["scope"] = String.Join(",", Permissions);
        
        var facebookClient = new FacebookClient();
        return facebookClient.GetLoginUrl(parameters);
    }
