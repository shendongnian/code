    var image = await WebUtils.GetPageAsImageAsync("http://www.stackoverflow.com");
---
    public class WebUtils
    {
        public static Task<Image> GetPageAsImageAsync(string url)
        {
            var tcs = new TaskCompletionSource<Image>();
            var thread = new Thread(() =>
            {
                WebBrowser browser = new WebBrowser();
                browser.Size = new Size(1280, 768);
                WebBrowserDocumentCompletedEventHandler documentCompleted = null;
                documentCompleted = async (o, s) =>
                {
                    browser.DocumentCompleted -= documentCompleted;
                    await Task.Delay(2000); //Run JS a few seconds more
                    browser.Width = browser.Document.Body.ScrollRectangle.Width;
                    browser.Height = browser.Document.Body.ScrollRectangle.Height;
                    Bitmap bitmap = new Bitmap(browser.Width, browser.Height);
                    browser.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                    tcs.TrySetResult(bitmap);
                    browser.Dispose();
                    Application.ExitThread();
                };
                browser.ScriptErrorsSuppressed = true;
                browser.DocumentCompleted += documentCompleted;
                browser.Navigate(url);
                Application.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }
    }
