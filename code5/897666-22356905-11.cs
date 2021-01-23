    //constructor
    public Form1()
    {
        InitializeComponent();
        //declare webBrowser1 before this
        //subscribe only once here
        webBrowser1.DocumentCompleted += browser_DocumentCompleted;
        //try these two if still fail
        //this.webBrowser1.AllowWebBrowserDrop = false; 
        //this.webBrowser1.ScrollBarsEnabled = false;
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
        webBrowser1.Navigate(new Uri(url));
        webBrowser1.Document.Focus();
    }
    private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        this.Text = e.Url.ToString() + " loaded";
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        //unsubscribe here
        webBrowser1.DocumentCompleted -= browser_DocumentCompleted;
        webBrowser1.Dispose();
    }
       
