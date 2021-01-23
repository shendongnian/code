    private Image TakeSnapShot(WebBrowser browser)
    {
         browser.Width = browser.Document.Body.ScrollRectangle.Width;
         browser.Height= browser.Document.Body.ScrollRectangle.Height;
         Bitmap bitmap = new Bitmap(browser.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, browser.Height);
         browser.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
         return bitmap;
    }
