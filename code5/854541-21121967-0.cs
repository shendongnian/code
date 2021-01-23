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
                wb.LoadCompleted += wb_LoadCompleted;
            }
            void webb_LoadCompleted(object sender, NavigationEventArgs e)
            {
                mshtml.HTMLDocument doc = webb.Document as mshtml.HTMLDocument;
                textBox1.Text = doc.getElementById("lastPrice").ToString();
            }
                
         }
