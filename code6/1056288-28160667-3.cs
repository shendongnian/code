    public class SslClientCertActionFilterAttribute : ActionFilterAttribute
    {
        public List<string> AllowedThumbprints = new List<string>()
		{
			"0011223344556677889900112233445566778899",
			"1122334455667788990011223344556677889900" 
		};
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            
            if (!AuthorizeRequest(request))
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
        private bool AuthorizeRequest(HttpRequestMessage request)
        {
            if (request==null)
                throw new ArgumentNullException("request");
            var clientCertificate = request.GetClientCertificate();
            if (clientCertificate == null || AllowedThumbprints == null || AllowedThumbprints.Count < 1)
            {
                return false;
            }
            foreach (var thumbprint in AllowedThumbprints)
            {
                if (clientCertificate.Thumbprint != null && clientCertificate.Thumbprint.Equals(thumbprint, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
