    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            this.progressBar1.Visible = false;
            this.progressBar1.Enabled = false;
        }
    
        Downloader downloader;
    
        /// <summary>
        /// starts \ stop button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //if downloader is not null then abort it
            if (downloader != null)
            {
                downloader.Abort();
                return;
            }
    
            //setup and start the downloader
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Enabled = true;
            this.progressBar1.Visible = true;
            this.downloader = new Downloader();
            this.downloader.Progress += downloader_Progress;
            this.downloader.Completed += downloader_Completed;
            this.downloader.Cancelled += downloader_Cancelled;
            this.downloader.Start();
        }
    
        /// <summary>
        /// downloader cancelled event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void downloader_Cancelled(object sender, EventArgs e)
        {
            this.unhookDownloader();
    
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate
                {
                    this.progressBar1.Enabled = false;
                    this.progressBar1.Visible = false;
                    MessageBox.Show(this, "Cancelled");
                });
            else
            {
                this.progressBar1.Enabled = false;
                this.progressBar1.Visible = false;
                MessageBox.Show(this, "Cancelled");
            }
    
        }
    
        /// <summary>
        /// downloader completed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void downloader_Completed(Downloader sender, Downloader.DownloaderCompletedEventArgs e)
        {
            this.unhookDownloader();
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate
                {
                    this.progressBar1.Enabled = false;
                    this.progressBar1.Visible = false;
                    this.pictureBox1.Image = e.Bitmap;
                    MessageBox.Show(this, "Completed");
                });
            else
            {
                this.progressBar1.Enabled = false;
                this.progressBar1.Visible = false;
                this.pictureBox1.Image = e.Bitmap;
                MessageBox.Show(this, "Completed");
            }
        }
    
        /// <summary>
        /// downloader progress event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void downloader_Progress(Downloader sender, Downloader.DownloaderProgressEventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
                this.progressBar1.Invoke((MethodInvoker)delegate
                {
                    this.progressBar1.Value = e.Completed;
                    this.progressBar1.Maximum = e.Total;
                });
            else
            {
                this.progressBar1.Value = e.Completed;
                this.progressBar1.Maximum = e.Total;
            }
    
        }
    
        /// <summary>
        /// unhooks the events handlers and sets the downloader to null
        /// </summary>
        void unhookDownloader()
        {
            this.downloader.Progress -= downloader_Progress;
            this.downloader.Completed -= downloader_Completed;
            this.downloader.Cancelled -= downloader_Cancelled;
            this.downloader = null;
        }
    }
