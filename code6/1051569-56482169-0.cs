    // Add bearer token authentication middleware.
    app.UseWindowsAzureActiveDirectoryBearerAuthentication(
    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
    {
      // The id of the client application that must be registered in Azure AD.
      TokenValidationParameters = new TokenValidationParameters { ValidAudience = clientId },
      // Our Azure AD tenant (e.g.: contoso.onmicrosoft.com).
      Tenant = tenant,
      Provider = new OAuthBearerAuthenticationProvider
      {
        // This is where the magic happens. In this handler we can perform additional
        // validations against the authenticated principal or modify the principal.
        OnValidateIdentity = async context =>
        {
          try
          {
            // Retrieve user JWT token from request.
            var authorizationHeader = context.Request.Headers["Authorization"].First();
            var userJwtToken = authorizationHeader.Substring("Bearer ".Length).Trim();
    
            // Get current user identity from authentication ticket.
            var authenticationTicket = context.Ticket;
            var identity = authenticationTicket.Identity;
    
            // Credential representing the current user. We need this to request a token
            // that allows our application access to the Azure Graph API.
            var userUpnClaim = identity.FindFirst(ClaimTypes.Upn);
            var userName = userUpnClaim == null
              ? identity.FindFirst(ClaimTypes.Email).Value
              : userUpnClaim.Value;
            var userAssertion = new UserAssertion(
              userJwtToken, "urn:ietf:params:oauth:grant-type:jwt-bearer", userName);
    
            // Credential representing our client application in Azure AD.
            var clientCredential = new ClientCredential(clientId, applicationKey);
    
            // Get a token on behalf of the current user that lets Azure AD Graph API access
            // our Azure AD tenant.
            var authenticationResult = await authenticationContext.AcquireTokenAsync(
              azureGraphApiUrl, clientCredential, userAssertion).ConfigureAwait(false);
    
            // Create Graph API client and give it the acquired token.
            var activeDirectoryClient = new ActiveDirectoryClient(
              graphApiServiceRootUrl, () => Task.FromResult(authenticationResult.AccessToken));
    
            // Get current user groups.
            var pagedUserGroups =
              await activeDirectoryClient.Me.MemberOf.ExecuteAsync().ConfigureAwait(false);
            do
            {
              // Collect groups and add them as role claims to our current principal.
              var directoryObjects = pagedUserGroups.CurrentPage.ToList();
              foreach (var directoryObject in directoryObjects)
              {
                var group = directoryObject as Group;
                if (group != null)
                {
                  // Add ObjectId of group to current identity as role claim.
                  identity.AddClaim(new Claim(identity.RoleClaimType, group.ObjectId));
                }
              }
              pagedUserGroups = await pagedUserGroups.GetNextPageAsync().ConfigureAwait(false);
            } while (pagedUserGroups != null);
          }
          catch (Exception e)
          {
            throw;
          }
        }
      }
    });
