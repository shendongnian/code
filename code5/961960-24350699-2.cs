    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret)) 
            {
                context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");
                context.Rejected();
                return;
            }
            ApplicationDatabaseContext dbContext = context.OwinContext.Get<ApplicationDatabaseContext>();
            ApplicationUserManager userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            if (dbContext == null)
            {
                context.SetError("server_error");
                context.Rejected();
                return;
            }
            
            try
            {
                AppClient client = await dbContext
                    .Clients
                    .FirstOrDefaultAsync(clientEntity => clientEntity.Id == clientId);
                if (client != null && userManager.PasswordHasher.VerifyHashedPassword(client.ClientSecretHash, clientSecret) == PasswordVerificationResult.Success)
                {
                    // Client has been verified.
                    context.OwinContext.Set<AppClient>("oauth:client", client);
                    context.Validated(clientId);
                }
                else
                {
                    // Client could not be validated.
                    context.SetError("invalid_client", "Client credentials are invalid.");
                    context.Rejected();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                context.SetError("server_error");
                context.Rejected();
            }
      }
