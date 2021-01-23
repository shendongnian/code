    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WebBrowserApp
    {
        public partial class MainForm : Form
        {
            WebBrowser webBrowser;
    
            public MainForm()
            {
                InitializeComponent();
    
                // create a WebBrowser
                this.webBrowser = new WebBrowser();
                this.webBrowser.Dock = DockStyle.Fill;
                this.Controls.Add(this.webBrowser);
    
                this.Load += MainForm_Load;
            }
    
            // Form Load event handler
            async void MainForm_Load(object sender, EventArgs e)
            {
                // cancel the whole operation in 30 sec
                var cts = new CancellationTokenSource(30000);
    
                var urls = new String[] { 
                        "http://www.example.com", 
                        "http://www.gnu.org", 
                        "http://www.debian.org" };
    
                await NavigateInLoopAsync(urls, cts.Token);
            }
    
            // navigate to each URL in a loop
            async Task NavigateInLoopAsync(string[] urls, CancellationToken ct)
            {
                foreach (var url in urls)
                {
                    ct.ThrowIfCancellationRequested();
                    var html = await NavigateAsync(ct, () => 
                        this.webBrowser.Navigate(url));
                    Debug.Print("url: {0}, html: \n{1}", url, html);
                }
            }
    
            // asynchronous navigation
            async Task<string> NavigateAsync(CancellationToken ct, Action startNavigation)
            {
                var onloadTcs = new TaskCompletionSource<bool>();
                EventHandler onloadEventHandler = null;
    
                WebBrowserDocumentCompletedEventHandler documentCompletedHandler = delegate
                {
                    // DocumentCompleted may be called several time for the same page,
                    // if the page has frames
                    if (onloadEventHandler != null)
                        return;
    
                    // so, observe DOM onload event to make sure the document is fully loaded
                    onloadEventHandler = (s, e) =>
                        onloadTcs.TrySetResult(true);
                    this.webBrowser.Document.Window.AttachEventHandler("onload", onloadEventHandler);
                };
    
                this.webBrowser.DocumentCompleted += documentCompletedHandler;
                try
                {
                    using (ct.Register(() => onloadTcs.TrySetCanceled(), useSynchronizationContext: true))
                    {
                        startNavigation();
                        // wait for DOM onload event, throw if cancelled
                        await onloadTcs.Task;
                    }
                }
                finally
                {
                    this.webBrowser.DocumentCompleted -= documentCompletedHandler;
                    if (onloadEventHandler != null)
                        this.webBrowser.Document.Window.DetachEventHandler("onload", onloadEventHandler);
                }
    
                // the page has fully loaded by now
    
                // optional: let the page run its dynamic AJAX code,
                // we might add another timeout for this loop
                do { await Task.Delay(500, ct); }
                while (this.webBrowser.IsBusy);
    
                // return the page's HTML content
                return this.webBrowser.Document.GetElementsByTagName("html")[0].OuterHtml;
            }
        }
    }
