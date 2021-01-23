    string yourUrl = "http://your-site.com/your-url-for-minification";
    string apikey = "YOUR-API-KEY-GOES-HERE";
    string provider = "0_mk"; // see provider strings list in API docs
    string uriString = string.Format(
        "http://tiny-url.info/api/v1/create?url={0}&apikey={1}&provider={2}&format=text",
        yourUrl, apikey, provider);
    System.Uri address = new System.Uri(uriString);
    System.Net.WebClient client = new System.Net.WebClient();
    try
    {
        string tinyUrl = client.DownloadString(address);
        Console.WriteLine(tinyUrl);
    }
    catch (Exception ex)
    {
        Console.WriteLine("network error occurred: {0}", ex);
    }
