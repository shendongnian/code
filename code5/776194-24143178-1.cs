    RefreshTokenHandler handler = new RefreshTokenHandler();
    liveAuthClient = new LiveAuthClient(ClientID, handler);
    var Session = liveAuthClient.InitializeAsync(scopes).Result.Session;
    if (Session == null)
    {
        webBrowser1.Navigate(liveAuthClient.GetLoginUrl(scopes));
    }
    else
    {
        try
        {
            this.liveConnectClient = new LiveConnectClient(Session);
            LiveOperationResult meRs = await this.liveConnectClient.GetAsync("me");
            dynamic meData = meRs.Result;
            if (string.Equals(meData.emails.account, MyAppUser.EmailAddress))
                MessageBox.Show("Successful login: " + meData.name);
        }
        catch (LiveAuthException aex)
        {
            MessageBox.Show("Failed to retrieve access token. Error: " + aex.Message);
        }
        catch (LiveConnectException cex)
        {
            MessageBox.Show("Failed to retrieve the user's data. Error: " + cex.Message);
        }
    }
