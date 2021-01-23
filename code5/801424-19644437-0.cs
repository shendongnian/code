    //for (int x = 0; x < imagesSatelliteUrls.Count; x++)
    Parallel.For(0, imagesSatelliteUrls.Count, /*new ParallelOptions { MaxDegreeOfParallelism = 20 },*/ x =>
    {
        if (!imagesSatelliteUrls[x].StartsWith("http://"))
        {
            imagesSatelliteUrls[x] = stringForSatelliteMapUrls + imagesSatelliteUrls[x];
        }
        using (WebClient client = new WebClient())
        {
            if (!imagesSatelliteUrls[x].Contains("href"))
            {
                client.DownloadFile(imagesSatelliteUrls[x],
                                    UrlsDir + "SatelliteImage" + counter.ToString("D6"));
            }
        }
        counter++;
    }); // end of Parallel.For
