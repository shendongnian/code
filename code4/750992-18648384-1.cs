    private void GoogleLoginForm_Load(object sender, EventArgs e)
    {
       wbGoogleLogin.Url = _loginUri;
    }
    
    private void wbGoogleLogin_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
        string fullPath = e.Url.ToString();
        WebBrowser control = sender as WebBrowser;
        if (control != null &&  !string.IsNullOrEmpty(control.DocumentTitle) && control.DocumentTitle.Contains("Success code"))
        {
           _OAuthVerifierToken = control.DocumentTitle.Replace("Success code=","");
           DialogResult = DialogResult.OK;
        }
    }
