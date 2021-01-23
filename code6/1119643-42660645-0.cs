     string tenantName = "yourdirectoryName.OnMicrosoft.com";
                string authString = "https://login.microsoftonline.com/" + tenantName;
                AuthenticationContext authenticationContext = new AuthenticationContext(authString, false);
                // Config for OAuth client credentials             
                ClientCredential clientCred = new ClientCredential(clientId, appKey);
                string resource = "https://graph.windows.net";
                string token;
                try
                {
                    AuthenticationResult authenticationResult = authenticationContext.AcquireToken(resource, clientCred);
                    token = authenticationResult.AccessToken;
                }
                catch (AuthenticationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Acquiring a token failed with the following error: {0}", ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Error detail: {0}", ex.InnerException.Message);
                    }
                }
