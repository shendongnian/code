    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    namespace Shipito
    {
        public class WebRequests
        {
            //Making property of HttpClient
            private static HttpClient _client;
             
            public static HttpClient Client
            {
                get { return _client; }
                set { _client = value; }
            }
            //method to download string from page
            public static async Task<string> LoadPageAsync(string p)
            {
                if (Client == null)// that means we need to login to page
                {
                    Client = await Login(Client);
                }
                return await Client.GetStringAsync(p);
            
            }
            // method for logging in
            public static async Task<HttpClient> Login(HttpClient client)
            {
                client = new HttpClient();
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", "someone@example.com"),
                        new KeyValuePair<string, string>("password", "SoMePasSwOrD")
                    });
                var response = await client.PostAsync("https://www.website.com/login.php", content);
                return client;
            }
            var page1Html = await LoadPageAsync("https://www.website.com/page1.php");
     
        }
    }
