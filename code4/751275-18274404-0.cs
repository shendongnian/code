    var th = new WebsiteThumbnailImage("http://www.google.com", 1024, 768, 256, 192);
    this.BackgroundImage =  await th.GenerateWebSiteThumbnailImage();
.
    class WebsiteThumbnailImage
    {
        public WebsiteThumbnailImage(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
        {
            this.Url = Url;
            this.BrowserWidth = BrowserWidth;
            this.BrowserHeight = BrowserHeight;
            this.ThumbnailHeight = ThumbnailHeight;
            this.ThumbnailWidth = ThumbnailWidth;
        }
        public string Url { set; get; }
        public int ThumbnailWidth { set; get; }
        public int ThumbnailHeight { set; get; }
        public int BrowserWidth { set; get; }
        public int BrowserHeight { set; get; }
        private Bitmap m_Bitmap = null;
        public Bitmap ThumbnailImage
        {
            get
            {
                return m_Bitmap;
            }
        }
        public Task<Bitmap> GenerateWebSiteThumbnailImage()
        {
            var tcs = new TaskCompletionSource<Bitmap>();
            WebBrowserDocumentCompletedEventHandler completed = null;
            WebBrowser m_WebBrowser = new WebBrowser();
            
            completed = (o, s) =>
            {
                _GenerateWebSiteThumbnailImageInternal(m_WebBrowser);
                m_WebBrowser.DocumentCompleted -= completed;
                m_WebBrowser.Dispose();
                tcs.TrySetResult(m_Bitmap);
            };
            m_WebBrowser.ScrollBarsEnabled = false;
            m_WebBrowser.DocumentCompleted += completed;
            m_WebBrowser.Navigate(Url);
            return tcs.Task;
            
        }
        private void _GenerateWebSiteThumbnailImageInternal(WebBrowser m_WebBrowser)
        {
            m_WebBrowser.ClientSize = new Size(this.BrowserWidth, this.BrowserHeight);
            m_WebBrowser.ScrollBarsEnabled = false;
            m_Bitmap = new Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height);
            m_WebBrowser.BringToFront();
            m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds);
            m_Bitmap = (Bitmap)m_Bitmap.GetThumbnailImage(ThumbnailWidth, ThumbnailHeight, null, IntPtr.Zero);
        }
    }
