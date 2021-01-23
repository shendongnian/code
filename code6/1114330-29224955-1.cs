    CookieContainer cookies = new CookieContainer();
    HttpClientHandler handler = new HttpClientHandler();
    handler.CookieContainer = cookies;
    
    HttpClient authClient = new HttpClient(handler);
    
    var uri = new Uri("http://localhost:4999/test_db/_session");
    
    authClient.BaseAddress = uri;
    authClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    var user = new LoginUserSecretModel
    {
        name = userKey,
        password = loginData.Password,
    };
    
    HttpResponseMessage authenticationResponse = authClient.PostAsJsonAsync("", user).Result;
    
    var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
