     private void button1_Click(object sender, EventArgs e)
        {
           using (FileDialog fd = new SaveFileDialog())
            {
                fd.Filter = "Image (*.png)|*.png";
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    new WebPageSnap(webBrowser1.Url.ToString(), fd.FileName);
                    //might take 3 or 4 seconds to save cauz it has to load again.
                }
            }
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
