    As Windows 8.1 does not support System.ServiceModel we haveto achieve it using REST
      
       private async void CallService()
                {
                    HttpClient httpClient = new System.Net.Http.HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:18362/Service1.svc/GetData");
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    string data = await response.Content.ReadAsStringAsync();
                    var dialog = new MessageDialog(data);
                    await dialog.ShowAsync();
                }
