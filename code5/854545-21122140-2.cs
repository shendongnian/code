        private System.Windows.Forms.WebBrowser wb;
        public Form1()
        {
            InitializeComponent();
            GetValue_Load(null, EventArgs.Empty);
        }
        private void GetValue_Load(object sender, EventArgs e)
        {
            wb = new System.Windows.Forms.WebBrowser();
            wb.DocumentCompleted += wb_DocumentCompleted;
            wb.Navigate("http://www.google.com");
        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MessageBox.Show("Document loading completed");
            //GET YOUR DOCUMENT HERE
        }
