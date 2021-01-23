    private void updater_Load(object sender, EventArgs e)
    {     
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (s, eArgs) =>
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("someUrl", "somePath");
            };
        worker.RunWorkerAsync();
    }
