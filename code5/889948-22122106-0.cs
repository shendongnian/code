    public partial class Form1 : Form
    {
        bool searched = false;
        long i = 1;
        private string IdNo { get { return "M" + i.ToString(); } }
        public Form1()
        {
            InitializeComponent(); 
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            i = 1;
            WebBrowser browser = new WebBrowser();
            string target = "http://www.SomePublicWebsite.com";
            browser.Navigate(target);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(XYZ);
        }
        private void XYZ(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser b = (WebBrowser)sender;
            if (b.ReadyState == WebBrowserReadyState. Complete)
            {
                if (searched == false)
                {
                    DoSearch(b); return;
                }
                if (b.Document.GetElementById("lblName") != null)
                {
                    string DateString = b.Document.GetElementById("lblDate").InnerHtml;
                    string NameString = b.Document.GetElementById("lblName").InnerHtml;
    
                    if (NameString != null && (NameString.Contains("XXXX") || NameString.Contains("xxxx")))
                        using (StreamWriter w = File.AppendText("log.txt"))
                            w.WriteLine("Id {0}, Date {1}, Name {2}", IdNo, DateString, NameString);
                }
                i++;
                DoSearch(b);
            }
        }
        private void DoSearch(WebBrowser wb)
        {
            wb.Document.GetElementById("txtId").InnerText = IdNo;
            wb.Document.GetElementById("btnSearch").InvokeMember("click");
            searched = true;
        }
    }
