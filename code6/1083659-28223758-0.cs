     private void button1_Click(object sender, EventArgs e)
        {
            new WebPageSnap("http://stackoverflow.com/questions/28222923/obtain-full-page-screenshot-from-webbrower-component", @"D:\SOF\goog.png");
        }
        class WebPageSnap
        {
            WebBrowser wb;
            string outFile;
            public WebPageSnap(string url, string outputFile)
            {
                wb = new WebBrowser();
                wb.ProgressChanged += wb_ProgressChanged;
                outFile = outputFile;
                wb.ScriptErrorsSuppressed = true;
                wb.ScrollBarsEnabled = false;
                wb.Navigate(url);
            }
            void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
            {
                if (e.CurrentProgress == e.MaximumProgress)
                {
                    wb.ProgressChanged -= wb_ProgressChanged;
                    try
                    {
                        int scrollWidth = 0;
                        int scrollHeight = 0;
                        scrollHeight = wb.Document.Body.ScrollRectangle.Height;
                        scrollWidth = wb.Document.Body.ScrollRectangle.Width;
                        wb.Size = new Size(scrollWidth, scrollHeight);
                        
                        Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
                        for (int Xcount = 0; Xcount < bitmap.Width; Xcount++)
                            for (int Ycount = 0; Ycount < bitmap.Height; Ycount++)
                                bitmap.SetPixel(Xcount, Ycount, Color.Black);
                        wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
                        bitmap.Save(outFile, ImageFormat.Png);
                    }
                    catch { }
                }
            }
            
        }
.
    ;Here's the result
