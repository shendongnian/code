    public class ChunkingCookieManagerWithSubdomains : ICookieManager
    {
        private readonly ChunkingCookieManager _chunkingCookieManager;
    
        public ChunkingCookieManagerWithSubdomains()
        {
            _chunkingCookieManager = new ChunkingCookieManager();
        }
    
        public string GetRequestCookie(IOwinContext context, string key)
        {
            return _chunkingCookieManager.GetRequestCookie(context, key);
        }
    
        public void AppendResponseCookie(IOwinContext context, string key, string value, CookieOptions options)
        {
            options.Domain = context.Request.Uri.GetHostWithoutSubDomain();
            _chunkingCookieManager.AppendResponseCookie(context, key, value, options);
        }
    
        public void DeleteCookie(IOwinContext context, string key, CookieOptions options)
        {
            options.Domain = context.Request.Uri.GetHostWithoutSubDomain();
            _chunkingCookieManager.DeleteCookie(context, key, options);
        }
    }
    public static class UriExtensions
    {
        public static string GetHostWithoutSubDomain(this Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;
                if (host.Split('.').Length > 2)
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.LastIndexOf(".", lastIndex - 1);
                    return host.Substring(index + 1);
                }
                else
                {
                    return host;
                }
            }
            return null;
        }
    }
