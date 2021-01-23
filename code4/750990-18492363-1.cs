    var parameters = new OAuth2Parameters()
    {
        //Client 
        ClientId = CLIENT_ID,
        ClientSecret = CLIENT_SECRET,
        RedirectUri = redirectUri,
        Scope = "https://www.google.com/m8/feeds",
        ResponseType = "code"
    };
    
    //User clicks this auth url and will then be sent to your redirect url with a code parameter
    var authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
    .
    .
    .
    //using the code parameter
    parameters.AccessCode = code;
    OAuthUtil.GetAccessToken(parameters);
    var settings = new RequestSettings(applicationName, parameters);
    var cr = new ContactsRequest(settings);
    //Now you can use contacts as you would have before
