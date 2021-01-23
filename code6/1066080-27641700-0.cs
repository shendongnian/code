    public static Image resizeImage(Image imgToResize, Size size)
        {
           return (Image)(new Bitmap(imgToResize, size));
        }
    
        objBitmap = resizeImage(objBitmap, new Size(size1,size2));
