            _xmppConnection.Server = SERVER_NAME;
            _xmppConnection.ConnectServer = SERVER_NAME;
            _xmppConnection.Username = objxmppData.UserName;
            _xmppConnection.Password = objxmppData.password;
            **_xmppConnection.RegisterAccount = true;**
            _xmppConnection.Open();
            _xmppConnection.OnAuthError += loginFailed;
            _xmppConnection.OnLogin += new ObjectHandler(xmpp_OnLogin);
