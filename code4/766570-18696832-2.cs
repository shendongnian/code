    private async Task DownloadFile()
    {
        WebClient client = new WebClient();
        using(var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60))
        {        
            var downloadTask =
                Task.Run(
                    () =>
                        client.DownloadFile("http://www.worldofcats.com/bigkitty.zip",
                            "c:\\cats\\"),
                     cts.Token
                 );
            await downloadTask;
        }
    }
        
