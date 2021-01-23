    private static void Main(string[] args)
        {
            string uri = "http://www.example.com/";
            string email = "email@example.com";
            string password = "secret123";
            
            var client = new WebClient();
            // Adding custom headers
            client.Headers.Add("ILikeTurtles", "true");
            
            // Adding values to the querystring
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["email"] = email;
            query["password"] = password;
            string queryString = query.ToString();
            // Uploadstring does a POST request to the specified server
            client.UploadString(uri, queryString);
        }
