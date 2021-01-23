    using System;
    using System.Text;
    using System.Net;
    using System.Collections.Specialized;
    using Newtonsoft.Json;
    
    namespace JSONAPITest
    {
        public class API_Response
        {
            public bool IsError { get; set; }
            public string ErrorMessage { get; set; }
            public string ResponseData { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string response = Http.Post("http://yoursite.com/api_server.php", new NameValueCollection() {
                    { "api_method", "loginUser" },
                    { "api_data",   "{ \"username\":\"test\", \"password\":\"1234\" }" }
                });
    
                API_Response r = JsonConvert.DeserializeObject<API_Response>(response);
    
                if (!r.IsError && r.ResponseData == "SUCCESS")
                {
                    Console.WriteLine("login success");
                }
                else
                {
                    Console.WriteLine("login error, reason is: {0}",
                        r.ErrorMessage);
                }
    
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    
        public static class Http
        {
            public static String Post(string uri, NameValueCollection pairs)
            {
                byte[] response = null;
                using (WebClient client = new WebClient())
                {
                    response = client.UploadValues(uri, pairs);
                }
                return Encoding.Default.GetString(response);
            }
        }
    }
