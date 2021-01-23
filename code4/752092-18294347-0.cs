        System.Net.WebClient wc = new System.Net.WebClient();
        public void Initialize(object sender, EventArgs e)
        {
            wc.DownloadStringCompleted += new System.Net.DownloadStringCompletedEventHandler(done);
        }
        public string version = "1.0.0";
        public void done(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if (version != e.Result)
            {
                //Do your code here
            }
        }
