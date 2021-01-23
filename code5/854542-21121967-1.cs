        namespace BitcoinValueScraper
        {
            public partial class GetValue : Form
            {
                System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
                public GetValue()
                {
                    InitializeComponent();
                }
                
                private void GetValue_Load(object sender, EventArgs e)
		{
			wb.Navigate("www.mtgox.com");
			wb.DocumentCompleted += wb_LoadCompleted;
		}
		void wb_LoadCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlDocument doc = wb.Document;
			textBox1.Text = doc.GetElementById("lastPrice").ToString();
		}        
             }
