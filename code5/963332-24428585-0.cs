    public async void login(string user, string passwrd)
    {
        
        string serviceURL = "";
        string parameters = "";
        HttpClient restClient = new HttpClient();
        restClient.BaseAddress = new Uri(mBaseURL);
        restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, serviceURL);
        req.Content = new StringContent(parameters, Encoding.UTF8, "application/json");
        HttpResponseMessage response = null;
        string responseBodyAsText = "";
        try
        {
            response = await restClient.SendAsync(req);
            response.EnsureSuccessStatusCode();
            responseBodyAsText = await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            string ex = e.Message;
        }
        if (response.IsSuccessStatusCode==true)
        {
            dynamic data = JObject.Parse(responseBodyAsText);
            
        }
        else
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("User or password were incorrect");
            }
            else
            {
                MessageBox.Show("NNetwork connection error");
            }
        } 
    }
