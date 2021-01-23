    public static Action<AuthenticationTokenReceiveContext> receive = new Action<AuthenticationTokenReceiveContext>(c =>
    {
			if (!string.IsNullOrEmpty(c.Token))
			{
				
				c.DeserializeTicket(c.Token);
				//c.OwinContext.Environment["Properties"] = c.Ticket.Properties;
			}
    });
