    using (HttpClientHandler handler = new HttpClientHandler())
    {
        CookieContainer cookies = new CookieContainer();
        handler.CookieContainer = cookies;
        using (HttpClient httpClient = new HttpClient(handler))
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json; charset=UTF-8"));
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, m_base_url + "session/login");
            requestMessage.Content = new StringContent("{username:xxxxxx,password:yyyyyyy}"); ;
            HttpResponseMessage loginResponse = await httpClient.SendAsync(requestMessage);
            // The HttpClient should already have the cookies from the login so
            // no need to transfer
            requestMessage = new HttpRequestMessage(HttpMethod.Get, m_base_url + "session/logout");
            requestMessage.Content = new StringContent("{}");
            HttpResponseMessage logoutResponse = await httpClient.SendAsync(requestMessage);
        }
    }
