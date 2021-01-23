    public class MyPacScriptProxy : IWebProxy
    {
        protected string PacScriptUrl;
        public MyPacScriptProxy(string url)
        {
            PacScriptUrl = url;
        }
        public ICredentials Credentials { get; set; }
        public Uri GetProxy(Uri dest)
        {
            // you can return your GetProxyFromPac(dest, PacScriptUrl); result here
            if (dest.Host.EndsWith(".net")) {
                return null; // bypass proxy for .net websites
            }
            return new Uri("http://localhost:8888");
        }
        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
