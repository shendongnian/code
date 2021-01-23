    static internal async Task<TokenResponseModel> GetBearerToken(string siteUrl, string Username, string Password)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(siteUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        
        HttpContent requestContent = new StringContent("grant_type=password&username=" + Username + "&password=" + Password, Encoding.UTF8, "application/x-www-form-urlencoded");
        
        HttpResponseMessage responseMessage = await client.PostAsync("Token", requestContent);
        
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonMessage;
            using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync())
            {
                jsonMessage = new StreamReader(responseStream).ReadToEnd();
            }
            
            TokenResponseModel tokenResponse = (TokenResponseModel)JsonConvert.DeserializeObject(jsonMessage, typeof(TokenResponseModel));
            
            return tokenResponse;
        }
        else
        {
            return null;
        }
    }
