    List<Image> allTiffImages = null;
    int currentImageIndex = 0;
    
    private void btnLoadTiff_Click(object sender, EventArgs e)
    {
        images = new List<Image>();
    
        // Open a Stream and decode a TIFF image
        Stream imageStreamSource = new FileStream("filename.tif", FileMode.Open, FileAccess.Read, FileShare.Read);
        TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource,     BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
    
        foreach(BitmapSource bmpS in decoder.Frames)
        {
           Image img = new Image();
           img.Source = bmpS;
           img.Stretch = Stretch.None;
           img.Margin = new Thickness(10);
           images.Add(img);
        }
        if(images.Count > 0)
            pictureBox1.Image = images[0];
    }
    private void btnNextImage_Click(object sender, EventArgs e)
    {
        if(++currentImageIndex >= images.Count)
            currentImageIndex = 0;   
           // 0 cycles the images,
           // if you want to stop at last image,
           //   set currentImageIndex = images.Count - 1; 
        pictureBox1.Image = images[currentImageIndex];
    }
    private void btnPrevImage_Click(object sender, EventArgs e)
    {
        if(--currentImageIndex < 0)
            currentImageIndex = images.Count - 1;
           // images.Count - 1 cycles the images,
           // if you want to stop at first image,
           //   set currentImageIndex = 0; 
        pictureBox1.Image = images[currentImageIndex];
    }
