        private void CheckUpdates_Load(object sender, EventArgs e)
        {
            if(CheckConnection.IsConnectedToInternet())
                 backgroundWorker1.RunWorkerAsync();
        }
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            if(CheckConnection.IsConnectedToInternet())
                 backgroundWorker1.RunWorkerAsync();
        }
