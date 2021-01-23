    public async void Button1Click(object sender, EventArgs e)
    {
        HttpClient httpClient = new System.Net.Http.HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "Web service address");
        button1.Enabled = false;
        await httpClient.SendAsync(request);
        
        // this line will be called back on the main thread.
        button1.Enabled = true;
    }
