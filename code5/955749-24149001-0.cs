    try
    {
        using (var client = new WebClient())
        {
            jsonResult = client.DownloadString(serviceUri);
        }
    }
