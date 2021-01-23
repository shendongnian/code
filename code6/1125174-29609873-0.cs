    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantAuthorizationCode(
            OAuthGrantAuthorizationCodeContext context)
        {
            IAdfsAuthorizationProvider authorizationProvider =
                context.OwinContext
                       .GetAutofacLifetimeScope()
                       .Resolve<IAdfsAuthorizationProvider>();
            return base.GrantAuthorizationCode(context);
        }
    }
