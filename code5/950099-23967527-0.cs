    public bool ThumbnailCallback() {
            return true;
        }
        private void GetThumbnail(PaintEventArgs e)
        {
            Image.GetThumbnailImageAbort callback = 
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image image = new Bitmap(@"c:\FakePhoto.jpg");
            Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new
               IntPtr());
            e.Graphics.DrawImage(
               pThumbnail,
               10,
               10,
               pThumbnail.Width,
               pThumbnail.Height);
        }
