        //somewhere in the app
        private readonly FacebookClient _fb = new FacebookClient();
        private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }
            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                //you have an access token, you can proceed further 
                FBLoginSucceded(accessToken);
            }
            else
            {
                // errors when logging in
                MessageBox.Show(oauthResult.ErrorDescription);
            }
        }
