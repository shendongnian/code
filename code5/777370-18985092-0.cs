    BackgroundWorker backTask = new BackgroundWorker();
        public frmExtraUpdater()
        {
            backTask.DoWork += backTask_DoWork;
            backTask.RunWorkerCompleted += backTask_RunWorkerCompleted;
        }
        private void frmExtraUpdater_Shown(object sender, EventArgs e)
        {
            yourLabel.Text = "Downloading";
            backTask.RunWorkerAsync();
        }
        void backTask_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i < 8; i++)
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile(String.Format("https://dl.dropboxusercontent.com/u/110636189/MapleEmoticons/f{0}.bmp", i), Application.StartupPath + @"\Images\f" + i + ".bmp");
                backTask.ReportProgress(i * (100 / 8), String.Format("https://dl.dropboxusercontent.com/u/110636189/MapleEmoticons/f{0}.bmp", i));
            }
        }
        void backTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            yourLabel.Text = "Downloading" + e.UserState.ToString();
        }
        void backTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close(); 
        }
