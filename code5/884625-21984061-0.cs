    private async void MyEvent(object sender, EventHandler e)
    {
        systemStatusLabel.Text = await GetSystemStatusAsync();
    }
    
    private async Task<string> GetSystemStatusAsync()
    {
        WebClient myWebClient = new WebClient();
        myWebClient.Headers.Add("user-agent", "libcurl-agent/1.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        var myDataBuffer = await myWebClient.DownloadDataTaskAsync("http://example.com/SystemStatus");
        string download = Encoding.ASCII.GetString(myDataBuffer);
        if (download.IndexOf("is online") !=-1)
        {
            return "System is up";
        }
        else
        {
            return "System is down!";
        }
    }
