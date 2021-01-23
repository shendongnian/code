    TypeOfFiles files;
    var retryCount = 0;
    do
    {
        files = DownloadFiles();       
        if (retryCount > 0)
        {
            Console.WriteLine("Retrying {0} time", retryCount);
        }
    }
    while (files == null && retryCount++ < 3)
