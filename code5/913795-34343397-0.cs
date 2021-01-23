    public static class OAuthBearerAuthenticationExtensions
    {
    	public static IAppBuilder UseOAuthBearerAuthenticationExtended(this IAppBuilder app, OAuthBearerAuthenticationOptions options)
    	{
    		if (app == null)
    			throw new ArgumentNullException(nameof(app));
    
    		app.Use(typeof(OAuthBearerAuthenticationMiddlewareExtended), app, options);
    		app.UseStageMarker(PipelineStage.Authenticate);
    		return app;
    	}
    }
    
    internal class OAuthBearerAuthenticationHandlerExtended : AuthenticationHandler<OAuthBearerAuthenticationOptions>
    {
    	private readonly ILogger _logger;
    	private readonly string _challenge;
    
    	public OAuthBearerAuthenticationHandlerExtended(ILogger logger, string challenge)
    	{
    		_logger = logger;
    		_challenge = challenge;
    	}
    
    	protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
    	{
    		try
    		{
    			// Find token in default location
    			string requestToken = null;
    			string authorization = Request.Headers.Get("Authorization");
    			if (!string.IsNullOrEmpty(authorization))
    			{
    				if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
    				{
    					requestToken = authorization.Substring("Bearer ".Length).Trim();
    				}
    			}
    
    			// Give application opportunity to find from a different location, adjust, or reject token
    			var requestTokenContext = new OAuthRequestTokenContext(Context, requestToken);
    			await Options.Provider.RequestToken(requestTokenContext);
    
    			// If no token found, no further work possible
    			if (string.IsNullOrEmpty(requestTokenContext.Token))
    			{
    				return null;
    			}
    
    			// Call provider to process the token into data
    			var tokenReceiveContext = new AuthenticationTokenReceiveContext(
    				Context,
    				Options.AccessTokenFormat,
    				requestTokenContext.Token);
    
    			await Options.AccessTokenProvider.ReceiveAsync(tokenReceiveContext);
    			if (tokenReceiveContext.Ticket == null)
    			{
    				tokenReceiveContext.DeserializeTicket(tokenReceiveContext.Token);
    			}
    
    			AuthenticationTicket ticket = tokenReceiveContext.Ticket;
    			if (ticket == null)
    			{
    				_logger.WriteWarning("invalid bearer token received");
    				Context.Set("oauth.token_invalid", true);
    				return null;
    			}
    
    			// Validate expiration time if present
    			DateTimeOffset currentUtc = Options.SystemClock.UtcNow;
    
    			if (ticket.Properties.ExpiresUtc.HasValue &&
    				ticket.Properties.ExpiresUtc.Value < currentUtc)
    			{
    				_logger.WriteWarning("expired bearer token received");
    				Context.Set("oauth.token_expired", true);
    				return null;
    			}
    
    			// Give application final opportunity to override results
    			var context = new OAuthValidateIdentityContext(Context, Options, ticket);
    			if (ticket != null &&
    				ticket.Identity != null &&
    				ticket.Identity.IsAuthenticated)
    			{
    				// bearer token with identity starts validated
    				context.Validated();
    			}
    			if (Options.Provider != null)
    			{
    				await Options.Provider.ValidateIdentity(context);
    			}
    			if (!context.IsValidated)
    			{
    				return null;
    			}
    
    			// resulting identity values go back to caller
    			return context.Ticket;
    		}
    		catch (Exception ex)
    		{
    			_logger.WriteError("Authentication failed", ex);
    			return null;
    		}
    	}
    
    	protected override Task ApplyResponseChallengeAsync()
    	{
    		if (Response.StatusCode != 401)
    		{
    			return Task.FromResult<object>(null);
    		}
    
    		AuthenticationResponseChallenge challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
    
    		if (challenge != null)
    		{
    			OAuthChallengeContext challengeContext = new OAuthChallengeContext(Context, _challenge);
    			Options.Provider.ApplyChallenge(challengeContext);
    		}
    
    		return Task.FromResult<object>(null);
    	}
    }
    
    
    public class OAuthBearerAuthenticationMiddlewareExtended : AuthenticationMiddleware<OAuthBearerAuthenticationOptions>
    {
    	private readonly ILogger _logger;
    	private readonly string _challenge;
    
    	/// <summary>
    	/// Bearer authentication component which is added to an OWIN pipeline. This constructor is not
    	///             called by application code directly, instead it is added by calling the the IAppBuilder UseOAuthBearerAuthentication
    	///             extension method.
    	/// 
    	/// </summary>
    	public OAuthBearerAuthenticationMiddlewareExtended(OwinMiddleware next, IAppBuilder app, OAuthBearerAuthenticationOptions options)
    	  : base(next, options)
    	{
    		_logger = AppBuilderLoggerExtensions.CreateLogger<OAuthBearerAuthenticationMiddlewareExtended>(app);
    		_challenge = string.IsNullOrWhiteSpace(Options.Challenge) ? (!string.IsNullOrWhiteSpace(Options.Realm) ? "Bearer realm=\"" + this.Options.Realm + "\"" : "Bearer") : this.Options.Challenge;
    
    		if (Options.Provider == null)
    			Options.Provider = new OAuthBearerAuthenticationProvider();
    
    		if (Options.AccessTokenFormat == null)
    			Options.AccessTokenFormat = new TicketDataFormat(
    				Microsoft.Owin.Security.DataProtection.AppBuilderExtensions.CreateDataProtector(app, typeof(OAuthBearerAuthenticationMiddleware).Namespace, "Access_Token", "v1"));
    
    		if (Options.AccessTokenProvider != null)
    			return;
    
    		Options.AccessTokenProvider = new AuthenticationTokenProvider();
    	}
    
    	/// <summary>
    	/// Called by the AuthenticationMiddleware base class to create a per-request handler.
    	/// 
    	/// </summary>
    	/// 
    	/// <returns>
    	/// A new instance of the request handler
    	/// </returns>
    	protected override AuthenticationHandler<OAuthBearerAuthenticationOptions> CreateHandler()
    	{
    		return new OAuthBearerAuthenticationHandlerExtended(_logger, _challenge);
    	}
    }
