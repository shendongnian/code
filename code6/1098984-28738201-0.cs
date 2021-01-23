     public class CustomAuthenticateAttribute : Attribute, IAuthenticationFilter
        {
             
            public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
            {
                HttpRequestMessage request = context.Request;
                AuthenticationHeaderValue authorization = request.Headers.Authorization;
    
                if (authorization == null)
                    return;
    
                if (authorization.Scheme != "Bearer")
                    return;
    
                if (String.IsNullOrEmpty(authorization.Parameter))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Missing token", request);
                    return;
                }
    
                TokenL1 tokenL1;
                var validateToken = TokenHelper.DecryptToken(authorization.Parameter, out tokenL1);
                if (!validateToken)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Token invalid", request);
                    return;
                }
                if (!(tokenL1.tokenexpiry > DateTime.Now))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Token expire", request);
                    return;
                }
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenL1.email), new string[] { "user" });
    
                if (principal == null)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                    return;
                }
                else
                {
                    context.Principal = principal;
                }
            }
    
            public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
            {
                var challenge = new AuthenticationHeaderValue("Bearer");
                context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
                return Task.FromResult(0);
            }
            public bool AllowMultiple
            {
                get { return false; }
            }
        }
