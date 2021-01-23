    public partial class Form1 : Form
    {
        WebBrowser wb = new WebBrowser();
        public Form1()
        {
            InitializeComponent();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigate("D:\\page1.HTM");
          
        }
    
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int scrollWidth = wb.Document.Body.ScrollRectangle.Width;
            int scrollHeight = wb.Document.Body.ScrollRectangle.Height;
        }
    }
