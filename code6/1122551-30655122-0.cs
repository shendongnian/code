	const string publicClientId = "self";
	var prod = container.Resolve<IOAuthAuthorizationServerProvider>(new NamedParameter("publicClientId", publicClientId));
	var oAuthOptions = new OAuthAuthorizationServerOptions
	{
		TokenEndpointPath = new PathString("/Token"),
		Provider = prod,
		AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
		AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
		AllowInsecureHttp = true
	};
