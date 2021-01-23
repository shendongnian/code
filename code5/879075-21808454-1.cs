	private void EstablishSession(ClaimsPrincipal transformedPrincipal)
	{
		var sessionToken = new SessionSecurityToken(transformedPrincipal, TimeSpan.FromHours(8));
		FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
	}
