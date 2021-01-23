        private void button1_Click(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += BwOnDoWork;
            bw.RunWorkerAsync();
        }
        private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                WebBrowser wb = new WebBrowser();
            }
            catch (Exception ex)
            {
            }
        }
