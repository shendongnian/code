    var liveIdClient = new LiveAuthClient(clientId);
    var liveLoginResult = await liveIdClient.LoginAsync("wl.basic wl.signin".Split());
    if (liveLoginResult.Status == LiveConnectSessionStatus.Connected) {
        var token = new JObject();
        token.Add("authenticationToken", liveLoginResult.Session.AuthenticationToken);
        var user = await MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, token);
    }
