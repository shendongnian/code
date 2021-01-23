        public class YourClass
        {
            private const string URL = "http://your_path/ob.json";
            private string urlParameters = "?api_key=123";
    
            static void Main(string[] args)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
    
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
    
                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    // handle if false
                }  
            }
        }
