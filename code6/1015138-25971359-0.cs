    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    public class HttpHelper
    {
        
        public static async Task WaitForResponse()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await  client.GetAsync(new Uri("http://google.com"));
            }
        }
        public static async Task FireAndForget()
        {
            using (var client = new HttpClient())
            {
                client.GetAsync(new Uri("http://google.com"));
            }
        }
    }
}
