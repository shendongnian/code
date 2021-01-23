    protected override void OnStart(string[] args)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(getFileList);
                timer.Interval = 10000;
                timer.AutoReset = false;
                timer.Enabled = true;
            }
     private void getFileList(object sender, EventArgs e)
            {
                List<string> files = new List<string>();
                try
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(****);
