    public void Configuration(IAppBuilder app)
    {
        var x = app.GetDefaultSignInAsAuthenticationType();
        app.SetDefaultSignInAsAuthenticationType(x);
    }
