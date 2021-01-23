    class Program
    {
        static void Main(string[] args)
        {
            setProxies();
            Console.ReadLine();
        }
        private static void setProxies()
        {
            //Set our proxy information
            string fullproxyaddress = "http://localhost:8888";
            WebProxy myProxy = new WebProxy(fullproxyaddress);
            myProxy.Credentials = new NetworkCredential("1", "1");
            try
            {
                //Initialize our object using the created proxy
                //Make the request
                string html = new TimedWebClient { Timeout = 360000, Proxy = myProxy }.DownloadString("http://www.google.com");
                html = HttpUtility.HtmlDecode(html);
                Console.Write(html);
            }
            catch { Console.Write("Error!"); }
        }
    }
    class TimedWebClient : WebClient
    {
        // Timeout in milliseconds, default = 600,000 msec
        public int Timeout { get; set; }
        public Encoding enc { get; set; }
        public TimedWebClient()
        {
            this.Timeout = 600000;
            this.Encoding = Encoding.UTF8;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            objWebRequest.Proxy = this.Proxy;
            return objWebRequest;
        }
    }
