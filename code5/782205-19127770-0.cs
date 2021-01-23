        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Update();
        }
        private void updater_Load(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadFileAsync(new Uri("http://download827.mediafire.com/jl9c098fnedg/ncqun56uddq0y1d/Stephen+Swartz+-+Survivor+%28Feat+Chloe+Angelides%29.wav"), Application.StartupPath + "\\Stephen Swartz - Survivor (Feat Chloe Angelides).wav");
        }
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Close();
        }
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
        }
