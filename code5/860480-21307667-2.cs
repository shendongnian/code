    public class BasicAuthAttribute : RequestFilterAttribute {
        readonly string _realmName;
        readonly string _repositoryName;
        public BasicAuthAttribute(string realmName, string repositoryName = null)
        {
            _realmName = realmName;
            _repositoryName = repositoryName ?? realmName;
        }
        public override void Execute(IRequest req, IResponse res, object requestDto)
        {
            // Get the correct repository to authenticate against
            var repositories = HostContext.TryResolve<MyUserRepository[]>();
            MyUserRepository repository = null;
            if(repositories != null)
                repository = repositories.FirstOrDefault(r => r.Name == _repositoryName);
            // Determine if request has basic authentication
            var authorization = req.GetHeader(HttpHeaders.Authorization);
            if(repository != null && !String.IsNullOrEmpty(authorization) && authorization.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                // Decode the credentials
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authorization.Substring(6))).Split(':');
                if(credentials.Length == 2)
                {
                    // Try and match the credentials to a user
                    var password = repository.Users.GetValueOrDefault(credentials[0]);
                    if(password != null && password == credentials[1])
                    {
                        // Credentials are valid
                        return;
                    }
                }
            }
            // User requires to authenticate
            res.StatusCode = (int)HttpStatusCode.Unauthorized;
            res.AddHeader(HttpHeaders.WwwAuthenticate, string.Format("basic realm=\"{0}\"", _realmName));
            res.EndRequest();
        }
    }
