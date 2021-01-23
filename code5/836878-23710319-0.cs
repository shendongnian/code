	public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
	{
		public override void Create(AuthenticationTokenCreateContext context)
		{
			// Expiration time in seconds
			int expire = 5*60;
			context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddSeconds(expire));
			context.SetToken(context.SerializeTicket());
		}
		public override void Receive(AuthenticationTokenReceiveContext context)
		{
			context.DeserializeTicket(context.Token);
		}
	}
