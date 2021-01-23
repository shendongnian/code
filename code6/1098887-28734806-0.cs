    	public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			using (var userManager = _container.GetInstance<ApplicationUserManager>())
			{
				var user = await userManager.FindAsync(context.UserName, context.Password);
				if (user == null)
				{
					context.SetError("invalid_grant", "The user name or password is incorrect.");
					return;
				}
				ClaimsIdentity oAuthIdentity = await userManager.CreateIdentityAsync(user,
					context.Options.AuthenticationType);
				ClaimsIdentity cookiesIdentity = await userManager.CreateIdentityAsync(user,
					CookieAuthenticationDefaults.AuthenticationType);
				AuthenticationProperties properties = CreateProperties(user);
                
                // Below line adds additional claims in token.
				AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
				context.Validated(ticket);
				context.Request.Context.Authentication.SignIn(cookiesIdentity);
			}
		}
		public static AuthenticationProperties CreateProperties(AspNetUser user)
		{
			IDictionary<string, string> data = new Dictionary<string, string>
            {
	            {"Id", user.Id.ToString(CultureInfo.InvariantCulture)},
				{"http://axschema.org/namePerson", user.Nickname,},
                {"http://axschema.org/contact/email", user.Email,},
            };
			return new AuthenticationProperties(data);
		}
