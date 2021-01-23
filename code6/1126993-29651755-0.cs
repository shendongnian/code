        private void DownloadFile(string url, string localOutputPath)
        {
            var webClient = new WebClient();
            webClient.DownloadFileCompleted += Completed;
            webClient.DownloadProgressChanged += ProgressChanged;
            webClient.DownloadFileAsync(new Uri(url), localOutputPath);
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { 
            Console.WriteLine(e.ProgressPercentage + " %");
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("File download completed!");
        }
