    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await GetUser(context.UserName, context.Password);
            if(user.LastPasswordChangedDate.AddDays(20) < DateTime.Now)
               // user needs to change password
        }
    }
