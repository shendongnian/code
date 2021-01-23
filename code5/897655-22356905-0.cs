    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myMethod("http://www.msn.com"); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myMethod(textbox1.Text);
        }
        public void myMethod(string url)
        {
            webBrowser1.DocumentCompleted += browser_DocumentCompleted;
            //webBrowser1.Navigate(new Uri(url));
            webBrowser1.Navigate(Uri.UnescapeDataString(url));
            webBrowser1.Document.Focus();
        }
        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            this.Text = e.Url.ToString() + " loaded";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            webBrowser1.Dispose();
        } 
    }
