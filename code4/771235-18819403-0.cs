    private void Form1_Load(object sender, EventArgs e)
    {
        this.BackColor = System.Drawing.Color.DarkGray;
        this.webBrowser.ScrollBarsEnabled = false;
        this.webBrowser.Dock = DockStyle.None;
        this.webBrowser.Location = new System.Drawing.Point(0, 0);
        this.webBrowser.Size = new System.Drawing.Size(320, 200);
        DownloadAsync("http://www.example.com").ContinueWith((task) =>
        {
            var html = task.Result;
            MessageBox.Show(String.Format(
                "WebBrowser.Size: {0}, Document.Window.Size: {1}, Document.Body.ScrollRectangle: {2}\n\n{3}",
                this.webBrowser.Size,
                this.webBrowser.Document.Window.Size,
                this.webBrowser.Document.Body.ScrollRectangle.Size,
                html));
            this.webBrowser.Size = this.webBrowser.Document.Body.ScrollRectangle.Size;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    async Task<string> DownloadAsync(string url)
    {
        TaskCompletionSource<bool> onloadTcs = new TaskCompletionSource<bool>();
        WebBrowserDocumentCompletedEventHandler handler = null;
    
        handler = delegate
        {
            this.webBrowser.DocumentCompleted -= handler;
    
            // attach to subscribe to DOM onload event
            this.webBrowser.Document.Window.AttachEventHandler("onload", delegate
            {
                // each navigation has its own TaskCompletionSource
                if (onloadTcs.Task.IsCompleted)
                    return; // this should not be happening
                // signal the completion of the page loading
                onloadTcs.SetResult(true);
            });
        };
    
        // register DocumentCompleted handler
        this.webBrowser.DocumentCompleted += handler;
    
        // Navigate to url
        this.webBrowser.Navigate(url);
    
        // continue upon onload
        await onloadTcs.Task;
    
        // the document has been fully loaded, can access DOM here
    
        // return the current HTML snapshot
        return ((dynamic)this.webBrowser.Document.DomDocument).documentElement.outerHTML.ToString();
    }
