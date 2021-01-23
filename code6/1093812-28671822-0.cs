    [Test]
    public void RedirectTest()
    {
        // These lines are not relevant to the problem, but are included for completeness.
        HttpResponseMessage response;
        var client = new HttpClient();
        using (var authString = new StringContent(@"{username: ""theUser"", password: ""password""}", Encoding.UTF8, "application/json"))
        {
            response = client.PostAsync("http://host/api/authenticate", authString).Result;
        }
        string result = response.Content.ReadAsStringAsync().Result;
        var authorization = JsonConvert.DeserializeObject<CustomAutorization>(result);
        // Relevant from this point on.
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorization.Scheme, authorization.Token);
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.host+json;version=1");
    
        var requestUri = new Uri("http://host/api/getSomething");
        response = client.GetAsync(requestUri).Result;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
			// Authorization header has been set, but the server reports that it is missing.
			// It was probably stripped out due to a redirect.
            var finalRequestUri = response.RequestMessage.RequestUri; // contains the final location after following the redirect.
            if (finalRequestUri != requestUri) // detect that a redirect actually did occur.
            {
                if (IsHostTrusted(finalRequestUri)) // check that we can trust the host we were redirected to.
                {
                   response = client.GetAsync(finalRequestUri).Result; // Reissue the request. The DefaultRequestHeaders configured on the client will be used, so we don't have to set them again.
                }
            }
        }
        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }
    private bool IsHostTrusted(Uri uri)
    {
        // Do whatever checks you need to do here
        // to make sure that the host
        // is trusted and you are happy to send it
        // your authorization token.
        if (uri.Host == "host")
        {
            return true;
        }
        
		return false;
    }
