    Uri sid = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
    string callbackURL = sid.ToString();
    string facebookURL = "https://www.facebook.com/dialog/oauth?client_id=" + Uri.EscapeDataString(AppId) + "&display=popup&response_type=token&scope=publish_stream&redirect_uri=" + Uri.EscapeDataString(callbackURL);
    
    var startUri = new Uri(facebookURL);
    
    WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, new Uri(callbackURL));
    if (result.ResponseStatus == WebAuthenticationStatus.Success && !result.ResponseData.Contains("&error="))
    {
          string resultString = result.ResponseData.Replace("#", "&");
          AccessToken = GetQueryParameter(resultString, "access_token");
          wasSuccess = true;
          IsLoggedIn = true;
          CurrentUser = await FacebookApi.GetCurrentUserId();
    }
    
    return wasSuccess;
