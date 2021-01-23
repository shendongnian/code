    byte[] imgDatas = null;
    using (MemoryStream ms = imager.CaptureImageNow().MemoryStream ) 
    {
        imgDatas = ms.GetBuffer();
    }
    
    ImageConverter ic = new ImageConverter();
    Image img = (Image)ic.ConvertFrom(imgDatas);
    using (Bitmap bmp = new Bitmap(img))
    {
        this.PreviewImage( bmp );
    }
