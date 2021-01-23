            // Add a new middleware validating access tokens.
            app.UseOAuthValidation(options =>
            {
                // Automatic authentication must be enabled
                // for SignalR to receive the access token.
                options.AutomaticAuthenticate = true;
                options.Events = new OAuthValidationEvents
                {
                    // Note: for SignalR connections, the default Authorization header does not work,
                    // because the WebSockets JS API doesn't allow setting custom parameters.
                    // To work around this limitation, the access token is retrieved from the query string.
                    OnRetrieveToken = context =>
                    {
                        // Note: when the token is missing from the query string,
                        // context.Token is null and the JWT bearer middleware will
                        // automatically try to retrieve it from the Authorization header.
                        context.Token = context.Request.Query["access_token"];
                        return Task.FromResult(0);
                    }
                };
            });
