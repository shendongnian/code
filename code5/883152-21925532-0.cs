    [ImageOutputCache(Duration = 18000)]
    public void Image(int id)
    {
        Image image = ImageDAL.SelectSingle(e => e.ImageId == id); //EF Model
    
        WebImage webimage = new WebImage(image.Data); //image.Data (byte[])
    
        //resize, crop etc
    
        webimage.Write();
    }
