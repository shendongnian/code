    using System.Security.Claims;
    using System.Threading.Tasks;
    using IdentityServer3.AccessTokenValidation;
    using Owin;
    using Microsoft.Owin.Security.OAuth;
    //...
    public void Configuration(IAppBuilder app)
    {
        app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
        {
            Authority = "http://127.0.0.1/identityserver", 
            TokenProvider = new OAuthBearerAuthenticationProvider
            {
                OnValidateIdentity = AddClaim
            }
        });
    }
    private Task AddClaim(OAuthValidateIdentityContext context)
    {
        context.Ticket.Identity.AddClaim(new Claim("test", "123"));
        return Task.CompletedTask;
    }
