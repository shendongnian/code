        private WebClient updateDownloader = new WebClient();
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            bgWorker.ReportProgress(e.ProgressPercentage);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            updateDownloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(bgWorker_DoWork);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateDownloader.DownloadFileAsync(new Uri(UriGoesHere), PathToSave);
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
