    private void AttachHandlers()
    {
        string parameter = "Some Info";
        objXmpp.OnLogin += new ObjectHandler(sender => {
            objXmppArun_OnLogin(sender, parameter);
        });
    }
    private void objXmppArun_OnLogin(object sender, string extraParameter)
    {
    }
