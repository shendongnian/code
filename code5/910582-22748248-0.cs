    private async Task DownloadFile(string url)
    {
        if (!url.EndsWith(".pdf"))
        {
            return;
        }
        using (var client = new WebClient())
        {
            int nextIndex = Interlocked.Increment(ref count);
            await client.DownloadFileTaskAsync(url, "lecture" + nextIndex + ".pdf");
            listBox.Items.Add(url);
        }
    }
    private async void Button_OnClick(object sender, RoutedEventArgs e)
    {
        button.IsEnabled = false;
        await DownloadFiles(urlList);
        button.IsEnabled = true;
    }
    private async Task DownloadFiles(IEnumerable<string> urlList)
    {
        foreach (var url in urlList)
        {
            await DownloadFile(url);
        }
    }
