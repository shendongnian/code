    public Form1()
    {
        InitializeComponent();
        webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted; // Subscribe event
        webBrowser1.Navigate("http://www.offradio.gr/player"); // Navigate to radio stream
    }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        /*
        Look for the element containing the element with the track number
        I've chosen this one because it has an ID means it's always the same div
        */
        HtmlElement parent = webBrowser1.Document.GetElementById("show_info");
        if (parent != null) // This event fires multiple times. Sometimes this element hasn't been created yet
        {
            /*
            We know it's a childless node inside `#show_info`.
            So let's just search for it.
            */
            foreach (HtmlElement child in parent.GetElementsByTagName("span"))
            {
                    if (child.Children.Count == 0) // Check if it has children
                    {
                        string title = child.InnerText; // The result
                        break;
                    }
                }
            }
        }
