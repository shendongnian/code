        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // validate user credentials (demo!)
            // user credentials should be stored securely (salted, iterated, hashed yada)
            if (context.UserName != context.Password)
            {
                context.Rejected();
                return;
            }
            context.Validated();
        }
