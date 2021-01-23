    public ActionResult GetImage(/*probably some id*/)
    { 
        System.Drawing.Image img = generator.GenerateImage();
        ImageConverter converter = new ImageConverter();
        var bytes = (byte[])converter.ConvertTo(img, typeof(byte[]));
        return File(bytes, "image/jpg"); // if your image is jpg
    }
