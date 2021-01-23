    public static class DataServiceExtensions
    {
        public static void UseBasicAuthentification<T>(
            this DataService<T> service, string realm, IUserValidator validator)
        {
            service.ProcessingPipeline.ProcessingRequest += (_sender, _e) =>
            {
                if (!Authenticate(_e.OperationContext, validator))
                {
                    _e.OperationContext.ResponseHeaders.Add(
                         "WWW-Authenticate", "Basic realm=" + 
                            Convert.ToBase64String(
                            Encoding.UTF8.GetBytes(GlobalConfiguration.Realm)));
                    throw new DataServiceException(401, "401 Unauthorized");
                }
            };
        }
        static bool Authenticate(DataServiceOperationContext context,
            IUserValidator validator)
        {
            if (!context.RequestHeaders.AllKeys.Contains("Authorization"))
                return false;
            
            // Remember claims based security should be only be 
            // used over HTTPS  
            if (!context.Request.IsSecureConnection)
                return false;
            string authHeader = context.RequestHeaders["Authorization"];
            IPrincipal principal = null;
            if (TryGetPrincipal(authHeader, validator, out principal))
            {
                //context.User = principal;
                return true;
            }
            return false;
        }
        private static bool TryGetPrincipal(string authHeader,
            IUserValidator validator, out IPrincipal principal)
        {
            var protocolParts = authHeader.Split(' ');
            if (protocolParts.Length != 2)
            {
                principal = null;
                return false;
            }
            else if (protocolParts[0] == "Basic")
            {
                var parameter = Encoding.UTF8.GetString(
                    Convert.FromBase64String(protocolParts[1]));
                var parts = parameter.Split(':');
                
                if (parts.Length != 2)
                {
                    principal = null;
                    return false;
                }
                var username = parts[0];
                var password = parts[1];
                principal = validator.Validate(username, password);
                return principal != null;
            }
            else
            {
                principal = null;
                return false;
            }
        }
    }
    public interface IUserValidator
    {
        IPrincipal Validate(string username, string password);
    }
