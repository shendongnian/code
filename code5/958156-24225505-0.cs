    namespace WebScraperAsync005
    {
        public partial class Form1 : Form
        {
    
            // main logic
            static async Task ScrapSitesAsync(string[] urls, CancellationToken token)
            {
                using(var webBrowser = new WebBrowser())
                {
                    foreach (var url in urls)
                    {
                        Console.WriteLine("URL:\n" + url);
    
                        // cancel in 30s or when the main token is signalled
                        var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
                        navigationCts.CancelAfter((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
                        var navigationToken = navigationCts.Token;
    
                        // run the navigation task inside MessageLoopApartment
                        string html = await webBrowser.NavigateAsync(url, navigationToken);
    
                        Console.WriteLine("HTML:\n" + html);
                    }
                }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                this.button1.Enabled = false;
                try
                {
                    WebBrowserExt.SetFeatureBrowserEmulation(); // enable HTML5
    
                    var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);
    
                    await ScrapSitesAsync(
                        new[] { "http://example.com", "http://example.org", "http://example.net" },
                        cts.Token);
    
                    MessageBox.Show("Completed.");
                }
                catch (Exception ex)
                {
                    while (ex is AggregateException && ex.InnerException != null)
                        ex = ex.InnerException;
                    MessageBox.Show(ex.Message);
                }
                this.button1.Enabled = true;
            }
        }
    
        /// <summary>
        /// WebBrowserExt - WebBrowser extensions
        /// by Noseratio - http://stackoverflow.com/a/22262976/1768303
        /// </summary>
        public static class WebBrowserExt
        {
            const int POLL_DELAY = 500;
    
            // navigate and download 
            public static async Task<string> NavigateAsync(this WebBrowser webBrowser, string url, CancellationToken token)
            {
                // navigate and await DocumentCompleted
                var tcs = new TaskCompletionSource<bool>();
                WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);
    
                using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
                {
                    webBrowser.DocumentCompleted += handler;
                    try
                    {
                        webBrowser.Navigate(url);
                        await tcs.Task; // wait for DocumentCompleted
                    }
                    finally
                    {
                        webBrowser.DocumentCompleted -= handler;
                    }
                }
    
                // get the root element
                var documentElement = webBrowser.Document.GetElementsByTagName("html")[0];
    
                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    await Task.Delay(POLL_DELAY, token);
    
                    // continue polling if the WebBrowser is still busy
                    if (webBrowser.IsBusy)
                        continue;
    
                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop
    
                    html = htmlNow;
                }
    
                // consider the page fully rendered 
                token.ThrowIfCancellationRequested();
                return html;
            }
    
            // enable HTML5 (assuming we're running IE10+)
            // more info: http://stackoverflow.com/a/18333982/1768303
            public static void SetFeatureBrowserEmulation()
            {
                if (System.ComponentModel.LicenseManager.UsageMode !=     System.ComponentModel.LicenseUsageMode.Runtime)
                    return;
                var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    appName, 10000, RegistryValueKind.DWord);
            }
        }
    }
