    using System;
    using System.Text;
    using System.Net;
    using System.Collections.Specialized;
    using Newtonsoft.Json;
    
    namespace TemplateFive
    {
        public class API_Response
        {
            public bool IsError { get; set; }
            public string ErrorMessage { get; set; }
            public string ResponseData { get; set; }
        }
    
        public class Login_Request
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // request params
                string apiUrl = "https://yoursite.com/api_server.php";
                string apiMethod = "loginUser";
                Login_Request myLogin_Request = new Login_Request()
                {
                    username = "test",
                    password = "1234"
                };
    
                // make http post request
                string response = Http.Post(apiUrl, new NameValueCollection()
                {
                    { "api_method", apiMethod                                    },
                    { "api_data",   JsonConvert.SerializeObject(myLogin_Request) }
                });
    
                // decode json string to dto object
                API_Response r = 
                    JsonConvert.DeserializeObject<API_Response>(response);
    
                // check response
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
