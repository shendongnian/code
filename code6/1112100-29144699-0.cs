    static void Main(string[] args)
    {
        string domainAvailability = GetDomainAvailability("https://testapi.internet.bs/Domain/Check?ApiKey=testapi&Password=testpass&Domain=google.com");
        Console.WriteLine(domainAvailability);
        Console.Read();
    }
    public static string GetDomainAvailability(string url)
    {
        string content = string.Empty;
        using (WebClient wc = new WebClient())
        {
            content = wc.DownloadString(url);
        }
        string[] responseValues = null;
        if (!string.IsNullOrEmpty(content))
        {
            responseValues = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }
        else
        {
            return "empty response";
        }
        if (responseValues.Any(x => x.Contains("status=")))
        {
            return responseValues.FirstOrDefault(x => x.Contains("status=")).Split('=')[1];
        }
        else
        {
            return "status parameter not found";
        }
    }
