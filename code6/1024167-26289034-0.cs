    public class AspNetOwnerContext : IOwnerContext
    {
        public string CurrentOwnerId
        {
            get
            {
                string host = HttpContext.Current.Request.Url.Host;
                int index = host.IndexOf(".");
                string subdomain = host.Substring(0, index);
                return subdomain;
            }
        }
    }
