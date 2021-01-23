    SoapClient client = new SoapClient();
    LoginResult lr = client.login(new LoginScopeHeader(), username, password);
    client.SessionHeaderValue = new SforceService.SessionHeader();
    client.SessionHeaderValue.sessionId = li.sessionId;
    client.Url = loginResult.serverUrl;
