    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += OnPageCompleted;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Path.Combine(Environment.CurrentDirectory, "DemoPage.html"));
        }
        protected virtual void OnPageCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document == null)
            {
                return;
            }
            if (webBrowser1.Document.Body == null)
            {
                return;
            }
            HtmlElementCollection col = webBrowser1.Document.Body.GetElementsByTagName("li");
            if (col == null || col.Count == 0)
            {
                return;
            }
            foreach (HtmlElement elem in col)
            {
                if (elem == null || string.IsNullOrWhiteSpace(elem.InnerHtml))
                {
                    continue;
                }
                var links = elem.GetElementsByTagName("a");
                if (links == null || links.Count == 0)
                {
                    continue;
                }
                foreach (HtmlElement url in links)
                {
                    if (url == null || string.IsNullOrWhiteSpace(url.InnerHtml))
                    {
                        continue;
                    }
                    try
                    {
                        url.InvokeMember("click");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.GetType().FullName + "\r\n" + ex.Message);
                    }
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            webBrowser1.DocumentCompleted -= OnPageCompleted;
        }
    }
