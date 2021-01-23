    private string getPage()
    {
        using (WebClient client = new WebClient())
        {
                client.Headers.Add("user-agent", "foo");
                return client.DownloadString("http://www.yellowpages.co.za/");               
        }
    }
