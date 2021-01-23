    using(WebClient client = new WebClient())
    {
        var json = client.DownloadString(url);
        List<ZipCode> ll = JObject.Parse(json)["zip_codes"].ToObject<List<ZipCode>>();
    }
