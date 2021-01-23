        public static string RealUrlFromOwin(HttpRequestMessage request)
        {
            var owincontext = ((OwinContext) request.Properties["MS_OwinContext"]);
            var env = owincontext.Environment;
            var listenerContext = (System.Net.HttpListenerContext) env["System.Net.HttpListenerContext"];
            return listenerContext.Request.RawUrl;
        }
