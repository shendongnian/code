    private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
    {
		token = null;
		IEnumerable<string> authzHeaders;
		if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
		{
			return false;
		}
		var bearerToken = authzHeaders.ElementAt(0);
		token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
		return true;
	}
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		HttpStatusCode statusCode;
		string token;
		var authHeader = request.Headers.Authorization;
		if (authHeader == null)
		{
			// missing authorization header
			return base.SendAsync(request, cancellationToken);
		}
		if (!TryRetrieveToken(request, out token))
		{
			statusCode = HttpStatusCode.Unauthorized;
			return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
		}
		try
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			TokenValidationParameters validationParameters =
				new TokenValidationParameters()
				{
					AllowedAudience = ConfigurationManager.AppSettings["JwtAllowedAudience"],
					ValidIssuer = ConfigurationManager.AppSettings["JwtValidIssuer"],
					SigningToken = new BinarySecretSecurityToken(SymmetricKey)
				};
			IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters);
			Thread.CurrentPrincipal = principal;
			HttpContext.Current.User = principal;
			return base.SendAsync(request, cancellationToken);
		}
		catch (SecurityTokenValidationException e)
		{
			statusCode = HttpStatusCode.Unauthorized;
		}
		catch (Exception)
		{
			statusCode = HttpStatusCode.InternalServerError;
		}
		return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
	}
