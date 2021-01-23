     class Program
        {
            static void Main(string[] args)
            {
                var host = String.Format("http://{0}:8080/", Environment.MachineName);
                var server = CreateServer(host);
    
                TestBigDownload(host);
    
                Console.WriteLine("Done");
                server.Dispose();
            }
    
    
            private static void TestBigDownload(string host)
            {
                var httpclient = new HttpClient() { BaseAddress = new Uri(host) };
                var stream = httpclient.GetStreamAsync("bigresource").Result;
    
                var bytes = new byte[10000];
                var bytesread = stream.Read(bytes, 0, 1000);
            }
    
            private static IDisposable CreateServer(string host)
            {
                var server = WebApp.Start(host, app =>
                {
                    var config = new HttpConfiguration();
                    config.MapHttpAttributeRoutes();
                    app.UseWebApi(config);
                });
                return server;
            }
        }
    
    
    
    
        [Route("bigresource")]
        public class BigResourceController : ApiController
        {
            public HttpResponseMessage Get()
            {
                var sb = new StringBuilder();
                for (int i = 0; i < 10000; i++)
                {
                    sb.Append(i.ToString());
                    sb.Append(",");
                }
                var content = new StringContent(sb.ToString());
                var response = new HttpResponseMessage()
                {
                    Content = content
                };
    
                return response;
            }
        }
