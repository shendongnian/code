    public static Image resizeImage(Image imgToResize, Size size)
    {
       return (Image)(new Bitmap(imgToResize, size));
    }
    yourImage = resizeImage(yourImage, new Size(1280,1280));
