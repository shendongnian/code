    public class Downloader
    {
        /// <summary>
        /// Delegate Event Handler for the downloading progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DownloaderProgressEventHandler(Downloader sender, DownloaderProgressEventArgs e);
        /// <summary>
        /// Delegate Event Handler for the completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DownloaderCompletedEventHandler(Downloader sender, DownloaderCompletedEventArgs e);
        /// <summary>
        /// The completed event
        /// </summary>
        public event DownloaderCompletedEventHandler Completed;
        /// <summary>
        /// The cancelled event
        /// </summary>
        public event EventHandler Cancelled;
        /// <summary>
        /// the progress event
        /// </summary>
        public event DownloaderProgressEventHandler Progress;
        /// <summary>
        /// the running thread
        /// </summary>
        Thread thread;
        /// <summary>
        /// the aborting flag
        /// </summary>
        bool aborting = false;
        //the addresses
        String[] addr = new String[] { 
            "http://google.com/favicon.ico", 
            "http://microsoft.com/favicon.ico", 
            "http://freesfx.com/favicon.ico", 
            "http://yahoo.com/favicon.ico", 
            "http://downloadha.com/favicon.ico",
            "http://hp.com/favicon.ico", 
            "http://bing.com/favicon.ico", 
            "http://webassign.com/favicon.ico", 
            "http://youtube.com/favicon.ico", 
            "https://twitter.com/favicon.ico", 
            "http://cc.com/favicon.ico", 
            "http://stackoverflow.com/favicon.ico", 
            "http://vb6.us/favicon.ico", 
            "http://facebook.com/favicon.ico", 
            "http://flickr.com/favicon.ico", 
            "http://linkedin.com/favicon.ico",
            "http://blogger.com/favicon.ico",
            "http://blogfa.com/favicon.ico",
            "http://metal-archives.com/favicon.ico",
            "http://wordpress.com/favicon.ico",
            "http://metallica.com/favicon.ico",
            "http://wikipedia.org/favicon.ico", 
            "http://visualstudio.com/favicon.ico",
            "http://evernote.com/favicon.ico" 
        };
        /// <summary>
        /// Starts the downloader
        /// </summary>
        public void Start()
        {
            if (this.aborting)
                return;
            if (this.thread != null)
                throw new Exception("Already downloading....");
            this.aborting = false;
            this.thread = new Thread(new ThreadStart(runDownloader));
            this.thread.Start();
        }
        /// <summary>
        /// Starts the downloader
        /// </summary>
        /// <param name="addresses"></param>
        public void Start(string[] addresses)
        {
            if (this.aborting)
                return;
            if (this.thread != null)
                throw new Exception("Already downloading....");
            this.addr = addresses;
            this.Start();
        }
        /// <summary>
        /// Aborts the downloader
        /// </summary>
        public void Abort()
        {
            if (this.aborting)
                return;
            this.aborting = true;
            this.thread.Join();
            this.thread = null;
            this.aborting = false;
            if (this.Cancelled != null)
                this.Cancelled(this, EventArgs.Empty);
        }
        /// <summary>
        /// runs the downloader
        /// </summary>
        void runDownloader()
        {
            Bitmap favCollection = new Bitmap(96, 64);
            Graphics g = Graphics.FromImage(favCollection);
            for (var i = 0; i < this.addr.Length; i++)
            {
                if (aborting)
                    break;
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    try
                    {
                        byte[] dl = client.DownloadData(addr[i]);
                        using (var stream = new MemoryStream(dl))
                        {
                            using (var dlImg = new Bitmap(stream))
                            {
                                g.DrawImage(dlImg, (i % 6) * 16, (i / 6) * 16, 16, 16);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        using (var dlImg = new Bitmap(Properties.Resources.defaultFacIcon))
                        {
                            g.DrawImage(dlImg, (i % 6) * 16, (i / 6) * 16, 16, 16);
                        }
                    }
                }
                if (aborting)
                    break;
                if (this.Progress != null)
                    this.Progress(this, new DownloaderProgressEventArgs
                    {
                        Completed = i + 1,
                        Total = this.addr.Length
                    });
            }
            if (!aborting && this.Completed != null)
            {
                this.Completed(this, new DownloaderCompletedEventArgs
                {
                    Bitmap = favCollection
                });
            }
            this.thread = null;
        }
        /// <summary>
        /// Downloader progress event args
        /// </summary>
        public class DownloaderProgressEventArgs : EventArgs
        {
            /// <summary>
            /// Gets or sets the completed images
            /// </summary>
            public int Completed { get; set; }
            /// <summary>
            /// Gets or sets the total images
            /// </summary>
            public int Total { get; set; }
        }
        /// <summary>
        /// Downloader completed event args
        /// </summary>
        public class DownloaderCompletedEventArgs : EventArgs
        {
            /// <summary>
            /// Gets or sets the bitmap
            /// </summary>
            public Bitmap Bitmap { get; set; }
        }
    }
