    public interface IApiAuthenticationProvider
        {
            bool IsValid(string username, string password);
        }
    public static class ApiAuthenticationEncrypter
    {
        public static string Encrypt(string username, string password)
        {
            return ApiRSA.Encrypt(/*join username and password*/);
        }
        public static void Decrypt(string token, out string username, out string password)
        {
            var usernameAndPass = ApiRSA.Decrypt(token).Split(/*split username and password*/);
            username = usernameAndPass[0];
            password = usernameAndPass[1];
        }
    }
    public class ApiAuthenticationAttribute : ActionFilterAttribute
        {
            private IApiAuthenticationProvider AuthenticationProvider { get; set; }
    
            public ApiAuthenticationAttribute(Type apiAuthenticationType)
            {
                Debug.Assert(typeof(IApiAuthenticationProvider).IsAssignableFrom(apiAuthenticationType));
                AuthenticationProvider = (IApiAuthenticationProvider) Activator.CreateInstance(apiAuthenticationType);
            }
    
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                Debug.Assert(AuthenticationProvider != null);
    
                Object httpContextBase;
                bool isValid = actionContext.Request.Properties.TryGetValue("MS_HttpContext", out httpContextBase);
                bool isLocal = isValid && ((HttpContextBase)httpContextBase).Request.IsLocal;
    
                if (isLocal)
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }
    
    
                //// == Only Https request ==
                //if (!String.Equals(actionContext.Request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
                //{
                //    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                //    {
                //        Content = new StringContent("HTTPS Required")
                //    };
                //    return;
                //}
    
                // == Try to get Token ==
                string token;
                try
                {
                    token = actionContext.Request.Headers.GetValues("AuthenticationToken").First();
                }
                catch (Exception)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("AuthenticationToken not found"),
                    };
                    return;
                }
    
                // == Validate using validator provider ==
                try
                {
                    string username;
                    string password;
                    ApiAuthenticationEncrypter.Decrypt(token, out username, out password);
    
                    if (AuthenticationProvider.IsValid(username, password))
                        base.OnActionExecuting(actionContext);
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                    {
                        Content = new StringContent("Invalid UserName or Password")
                    };
                    return;
                }
            }
        }
