    /// <summary>
    /// When the url has code in it and contains a session_state get the code and do the GetTokenInformation
    /// </summary>
    private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
        if (e.Url.AbsoluteUri.Contains("code=") && e.Url.AbsoluteUri.Contains("session_state"))
        {
            string[] splited = e.Url.AbsoluteUri.Split(new char[] { '=', '&' });
            _code = splited[1];
            if (!string.IsNullOrWhiteSpace(_code)
                && !string.IsNullOrWhiteSpace(_redirectUri)
                && !string.IsNullOrWhiteSpace(_clientId))
            {
                GetTokenInformation(_code, _redirectUri, _clientId, _clientSecret);
            }
            else
            {
                _connected = false;
            }
        }
    }
