     public class BasicAuthMessageHandler : DelegatingHandler
        {
            private const string BasicAuthResponseHeader = "WWW-Authenticate";
            private const string BasicAuthResponseHeaderValue = "Basic";
            //[Inject]
            //public iUser Repository { get; set; }
            // private readonly iUser Repository;
            private readonly iUser Repository = new User();
    
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                AuthenticationHeaderValue authValue = request.Headers.Authorization;
    
                if (authValue == null || authValue.Scheme != BasicAuthResponseHeaderValue)
                {
                    return Unauthorized(request);
                }
                string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authValue.Parameter)).Split(new[] { ':' });
                if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
                {
                    return Unauthorized(request);
                }
                api_login user = Repository.Validate2(credentials[0], credentials[1]);
                if (user == null)
                {
                    return Unauthorized(request);
                }
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(user.username, BasicAuthResponseHeaderValue), null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
    
                return base.SendAsync(request, cancellationToken);
            }
    
            private Task<HttpResponseMessage> Unauthorized(HttpRequestMessage request)
            {
                var response = request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue); 
                var task = new TaskCompletionSource<HttpResponseMessage>(); 
                task.SetResult(response); 
                return task.Task;
            }
    
        }
