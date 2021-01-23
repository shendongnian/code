    public static Action<AuthenticationTokenCreateContext> create = new Action<AuthenticationTokenCreateContext>(c =>
    {
        c.SetToken(c.SerializeTicket());
    });
    public static Action<AuthenticationTokenReceiveContext> receive = new Action<AuthenticationTokenReceiveContext>(c =>
    {
        c.DeserializeTicket(c.Token);
        c.OwinContext.Environment["Properties"] = c.Ticket.Properties;
    });
