    private async void YourButton_Click(object sender, EventArgs args)
    {
        YourButton.Enabled = false;
        try
        {
          var tasks = new List<Task>();
          foreach (string url in Urls)
          {
            tasks.Add(CheckAsync(url));
          }
          await TaskEx.WhenAll(tasks);
        }
        finally
        {
          YourButton.Enabled = true;
        }
    }
    
    private async Task CheckAsync(string url)
    {
        bool found = await UrlResponseContainsAsync(url, "domainname.com");
        if (found)
        {
            slist.Add(url);
            label3.Text = "Total Found: " + slist.Count.ToString();
            textbox2.Text = "Working Url " + url;
        }
    }
    
    private async Task<bool> UrlResponseContainsAsync(string url, string find)
    {
        var request = WebRequest.Create(url);
        request.Timeout = 60 * 1000;
        using (WebResponse response = await request.GetResponseAsync())
        {
            using (var buffer = new BufferedStream(response.GetResponseStream()))
            using (var reader = new StreamReader(buffer))
            {
                string text = reader.ReadToEnd();
                return text.Contains(find);
            }
        }
    }
