    private void Form1_Shown(object sender, EventArgs e)
    {
        WebClient webClient = new WebClient();
        webClient.Proxy = null;
        webClient.Encoding = Encoding.UTF8;
        webClient.Headers.Add(@"Content-Type: application/json; charset=utf-8");
        webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
        webClient.UploadStringAsync(new Uri(Config.MessagingURL), "POST", json);
    }
