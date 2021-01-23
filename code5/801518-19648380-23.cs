        class ActiveDownloadJob
        {
            public DownloadData DownloadData;
            public ProgressBar ProgressBar;
            public WebClient WebClient;
            public ActiveDownloadJob(ExtractImages.DownloadData downloadData, ProgressBar progressBar, WebClient webClient)
            {
                this.DownloadData = downloadData;
                this.ProgressBar = progressBar;
                this.WebClient = webClient;
            }
        }
