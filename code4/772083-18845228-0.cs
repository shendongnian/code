    private async void getAllData()
       string uri = "http://webservice.com/wfwe";
       HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, uri);
       HttpResponseMessage response;
       response = await Client.sendMessageAsync(msg);
       string body = await response.Content.ReadAsStringAsync();
       
       GetApplications(body);
    }
