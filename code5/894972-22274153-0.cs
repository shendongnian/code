    private async Task TestCultureAsync()
    {
      Debug.WriteLine(CultureInfo.CurrentCulture);
      WebClient client = new WebClient();
      string s = await client.DownloadStringTaskAsync(new Uri("http://www.google.de"));
      Debug.WriteLine(CultureInfo.CurrentCulture);
    }
    var task1 = TestCultureAsync();
    var task2 = TestCultureAsync();
    var task3 = TestCultureAsync();
    await Task.WhenAll(task1, task2, task3);
