    protected void btn_print_Click(object sender, EventArgs e)
    {
        try
        {
            int width = 850;
            int height = 550;
            
            this.Page.Unload += delegate {
                Thumbnail1 thumbnail = new Thumbnail1(this.Page, 990, 1000, width, height);
                Bitmap image = thumbnail.GenerateThumbnail();
                image.Save(Server.MapPath("~") + "/Dwnld/Thumbnail.bmp");
                imagepath = Server.MapPath("~").ToString() + "\\Dwnld\\" + "Thumbnail.bmp";
                imagepath1 = Server.MapPath("~").ToString() + "\\Dwnld\\" + "Thumbnail.pdf";
                convetToPdf();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    ...
 
    public Thumbnail1(Page page, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
        {
            this.Page = page;
            this.BrowserWidth = BrowserWidth;
            this.BrowserHeight = BrowserHeight;
            this.Height = ThumbnailHeight;
            this.Width = ThumbnailWidth;
        }
    ...
    private void GenerateThumbnailInteral()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.ScrollBarsEnabled = false;
            webBrowser.Navigate(this.Url);
            webBrowser.DocumentStream = this.Page.Response.GetResponseStream()
            webBrowser.ClientSize = new Size(this.BrowserWidth, this.BrowserHeight);
            webBrowser.ScrollBarsEnabled = false;
            this.ThumbnailImage = new Bitmap(webBrowser.Bounds.Width, webBrowser.Bounds.Height);
            webBrowser.BringToFront();
            webBrowser.DrawToBitmap(ThumbnailImage, webBrowser.Bounds);
            this.ThumbnailImage = (Bitmap)ThumbnailImage.GetThumbnailImage(Width, Height, null, IntPtr.Zero);
        }
