            using (var stream = assembly.GetManifestResourceStream("Tasks.ASP.NET.SimpleOAuth2.client_secrets.json"))
            {
                flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    DataStore = new FileDataStore("Tasks.ASP.NET.Sample.Store"),
                    ClientSecretsStream = stream,
                    Scopes = new[] { TasksService.Scope.TasksReadonly }
                });
            }
            var uri = Request.Url.ToString();
            var code = Request["code"];
            if (code != null)
            {
                var token = flow.ExchangeCodeForTokenAsync(UserId, code,
                    uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;
                // Extract the right state.
                var oauthState = AuthWebUtility.ExtracRedirectFromState(
                    flow.DataStore, UserId, Request["state"]).Result;
                Response.Redirect(oauthState);
            }
            else
            {
                var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId,
                    CancellationToken.None).Result;
                if (result.RedirectUri != null)
                {
                    // Redirect the user to the authorization server.
                    Response.Redirect(result.RedirectUri);
                }
                else
                {
                    // The data store contains the user credential, so the user has been already authenticated.
                    service = new TasksService(new BaseClientService.Initializer
                    {
                        ApplicationName = "Tasks API Sample",
                        HttpClientInitializer = result.Credential
                    });
                }
            }
