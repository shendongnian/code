    private RestClient InitializeAndGetClient()
            {
                var cookieJar = new CookieContainer();
                var client = new RestClient("https://xxxxxxx")
                {
                    Authenticator = new HttpBasicAuthenticator("xxIDxx", "xxKeyxx"),
                    CookieContainer = cookieJar
                };
    
                return client;
            }
