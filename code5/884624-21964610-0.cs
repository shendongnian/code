        public project()
        {
            InitializeComponent();
           
            BackgroundWorker bw = new BackgroundWorker() { WorkerReportsProgress = true };
            bool isOnline = false;
            bw.DoWork += (sender, e) =>
            {
                
                //what happens here must not touch the form
                //as it's in a different thread
                isOnline = querysite();
            };
            bw.ProgressChanged += (sender, e) =>
            {
                //update progress bars here
            };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                //now you're back in the UI thread you can update the form
                if (isOnline)
                {
                    systemStatusLabel.Text = "System is up";
                }
                else
                {
                    systemStatusLabel.Text = "System is down!";
                }
                
            }; 
            
        }
        private bool querysite()
        {
            WebClient myWebClient = new WebClient();
            myWebClient.Headers.Add("user-agent", "libcurl-agent/1.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            byte[] myDataBuffer = myWebClient.DownloadData("http://example.com/SystemStatus");
            string download = Encoding.ASCII.GetString(myDataBuffer);
            bool isOnline = download.IndexOf("is online") != -1;
            return isOnline;            
            
        }  
