    private void btnUpload_Click(object sender, EventArgs e)
    {
        //First, convert the image to byte array so we can proceed.
        MemoryStream mStream = new MemoryStream();
        WriteableBitmap wbmp = new WriteableBitmap(bmp);
        wbmp.SaveJpeg(mStream, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
        mStream.Seek(0, SeekOrigin.Begin);
        var data = mStream.GetBuffer();
        // sync way
        this.UploadImage(data);
        lblImageURL.Visibility = System.Windows.Visibility.Visible;
        lblImageURL.Text = finalImageURL;
        // or async way that is better for UI operations
        Task.Factory.
             StartNew(() => this.UploadImage(data)).
             ContinueWith((task) =>
                          {                                                                                                                             
                           lblImageURL.Visibility = System.Windows.Visibility.Visible;
                           lblImageURL.Text = finalImageURL;
                          });
    }
 
