    public static void Main()
    {
        await MyMethodAsync();
    }
    
    static async Task MyMethodAsync()
    {
        await new DCMReportRetriever().Run().ConfigureAwait(continueOnCapturedContext: false);
    }
    
    private async Task Run()
    {
    
        ...
    
        foreach (_file f in files)
        {
            if (f.Status == "REPORT_AVAILABLE" && f.LastModifiedTime >= startDateSinceEpoch)
            {
                using (var stream = new FileStream(f.FileName + ".csv", FileMode.Append))
                {
                    new MediaDownloader(service).Download(f.Urls.ApiUrl, stream);
                }
            }
        }
    }
