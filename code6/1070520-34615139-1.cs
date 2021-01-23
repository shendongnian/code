    private async void Application_Startup(object sender, StartupEventArgs e) {
        var sessionID = string.Empty;
        var httpClient = new HttpClient();
        var url = "http://localhost:53988/Session";
        var response = await httpClient.GetAsync(url);
        if(response.IsSuccessStatusCode 
           && response.Content.Headers.ContentLength.GetValueOrDefault() > 0) {
            sessionID = await response.Content.ReadAsStringAsync();
        }
    }
