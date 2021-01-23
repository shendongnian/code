    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    namespace MyProject.Extensions
    {
        public static class WebBrowserExtensions
        {
            const int CompletionDelay = 250;
            private class WebBrowserCompletionHelper
            {
                public Stopwatch LastCompletion;
                public WebBrowserCompletionHelper()
                {
                    // create but don't start.
                    LastCompletion = new Stopwatch();
                }
                public void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
                {
                    WebBrowser browser = sender as WebBrowser;
                    if (browser != null)
                    {
                        LastCompletion.Restart();
                    }
                }
            }
            public static void NavigateAndWaitUntilComplete(this WebBrowser browser, Uri uri)
            {
                WebBrowserCompletionHelper helper = new WebBrowserCompletionHelper();
                try
                {
                    browser.DocumentCompleted += helper.DocumentCompleted;
                    browser.Navigate(uri);
                    Thread.Sleep(CompletionDelay);
                    Application.DoEvents();
                    while (browser.ReadyState != WebBrowserReadyState.Complete && helper.LastCompletion.ElapsedMilliseconds < CompletionDelay)
                    {
                        Thread.Sleep(CompletionDelay);
                        Application.DoEvents();
                    }
                }
                finally
                {
                    browser.DocumentCompleted -= helper.DocumentCompleted;
                }
            }
        }
    }
