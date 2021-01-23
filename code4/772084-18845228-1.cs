    private async void getAllData()
       string uri = "http://webservice.com/wfwe";
       HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, uri);
       HttpResponseMessage response;
       var client = new HttpClient();
       response = await client.GetAsync(msg);
       string body = await response.Content.ReadAsStringAsync();
       
       GetApplications(body);
    }
