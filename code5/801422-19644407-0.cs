    // Create a mock list of data
    string someImageUrl = "..."; // some test url of an image file
    string urlsDirectory = @"C:\Temp"; // some working directory
    var urls = new string[7 * 20];
    for (int i = 0; i < urls.Length; i += 7)
    {
        urls[i] = String.Format("Group {0}", (i / 7) + 1);
                
        for (int j = 1; j < 7; j++)
        {
            urls[i + j] = someImageUrl;
        }
    }
    // Download 6 files at a time.
    var client = new HttpClient();
    for (int i = 0; i < urls.Length; i += 7)
    {
        var directoryPath = Directory.CreateDirectory(Path.Combine(urlsDirectory, urls[i])).FullName;
        var tasks = urls.Skip(i + 1).Take(6).Select(url =>
        {
            return client.GetAsync(url);
        }).ToArray();
        Task.WaitAll(tasks);
        for (int j = 0; j < tasks.Length; j++)
        {
            var response = tasks[j].Result;
            using (var fs = new FileStream(Path.Combine(directoryPath, String.Format("Image {0}.jpg", j + 1)), FileMode.OpenOrCreate))
            {
                using (var responseStream = response.Content.ReadAsStreamAsync().Result)
                {
                    responseStream.CopyTo(fs);
                }
            }
        }
    }
