    Dictionary<string, string> pages = new Dictionary<string, string>();
    Dictionary<string, string> errors = new Dictionary<string, string>();
    string[] urls = new string[] { "http://www.google.com", "http://www.bbc.co.uk" };
    Parallel.ForEach<string>(urls, (url) =>
    {
        var webClient = new System.Net.WebClient();
        try
        {
            pages[url] = webClient.DownloadString(new Uri(url));
        }
        catch(Exception ex)
        {
            errors[url] = ex.Message;
        }                
    });
    // The successful
    foreach(var kvp in pages)
    {
        Console.WriteLine(kvp.Key);
        //Console.WriteLine(kvp.Value);
    }
    // The failures
    foreach (var kvp in errors)
    {
        Console.WriteLine(kvp.Key);
        //Console.WriteLine(kvp.Value);
    }
