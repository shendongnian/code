    public class DNSHelper
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string GetUsername(System.Web.HttpRequest request)
        {
            try
            {
                return request.LogonUserIdentity.Name;
            }
            catch (InvalidOperationException ioex)
            {
                if (System.Web.HttpContext.Current.User != null)
                {
                    return System.Web.HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
