    public Emgu.CV.Image<Bgr, Byte> imageToEmguImage(System.Drawing.Image imageIn)
    {
        Bitmap bmpImage = new Bitmap(imageIn);
        Emgu.CV.Image<Bgr, Byte> imageOut = new Emgu.CV.Image<Bgr, Byte>(bmpImage);
        return imageOut;
    }
