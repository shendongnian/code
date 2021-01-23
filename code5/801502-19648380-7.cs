    public static void AddImageDownloadsToQueue(Queue<DownloadData> downloadQueue, List<string> FirstTags, List<string> LastTags, List<string> Maps, string LocalFileDir, string UrlsDir)
    {
        for (int i = 0; i < Maps.Count; i++)
        {
            string imageSatelliteUrl = ... // compose URL for satellite image
            
            downloadQueue.Enqueue(
                new DownloadData(
                    new Uri(imageSatelliteUrl),
                    UrlsDir + "SatelliteImage" + x.ToString("D6")
                )
            );
    
            string imageRainUrl = ... // compose URL for rain image
            
            downloadQueue.Enqueue(
                new DownloadData(
                    new Uri(imageRainUrl),
                    UrlsDir + "RainImage" + x.ToString("D6")
                )
            );
        }
    }
