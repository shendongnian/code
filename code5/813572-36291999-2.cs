    using (var client = new HttpClient{ BaseAddress = new Uri(BaseAddress) })
    {
        var token = client.PostAsync("Token", 
            new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",user.UserName),
                new KeyValuePair<string,string>("password","P@ssW@rd")
            })).Result.Content.ReadAsAsync<AuthenticationToken>().Result;
    
        client.DefaultRequestHeaders.Authorization = 
               new AuthenticationHeaderValue(token.token_type, token.access_token);
        // actual requests from your api follow here . . .
    }
