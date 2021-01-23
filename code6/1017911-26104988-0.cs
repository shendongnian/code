    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Branch the pipeline here for requests that start with "/signalr"
            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    EnableJSONP = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR<ClientAccessPolicyConnection>("/clientaccesspolicy.xml");
        }
    }
-
    public class ClientAccessPolicyConnection : PersistentConnection
    {
        public override Task ProcessRequest(Microsoft.AspNet.SignalR.Hosting.HostContext context)
        {
            string[] urlArray = context.Request.Url.ToString().Split('/');
            string path = urlArray[urlArray.Length - 1];
            if (path.Equals("clientaccesspolicy.xml", StringComparison.InvariantCultureIgnoreCase))
            {
                //Convert policy to byteArray
                var array = Encoding.UTF8.GetBytes(ClientAccessPolicy);
                var segment = new ArraySegment<byte>(array);
                //Write response
                context.Response.ContentType = "text/xml";
                context.Response.Write(segment);
                //Return empty task to escape from SignalR's default Connection/Transport checks.
                return EmptyTask;
            }
             
            return EmptyTask;
        }
        private static readonly Task EmptyTask = MakeTask<object>(null);
        public static Task<T> MakeTask<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(value);
            return tcs.Task;
        }
        public static readonly string ClientAccessPolicy =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                    + "<access-policy>"
                       + "<cross-domain-access>"
                         + "<policy>"
                           + "<allow-from http-request-headers=\"*\">"
                                + "<domain uri=\"*\"/>"
                           + "</allow-from>"
                           + "<grant-to>"
                                + "<resource path=\"/\" include-subpaths=\"true\"/>"
                           + "</grant-to>"
                        + "</policy>"
                    + "</cross-domain-access>"
                  + "</access-policy>";
    }
