     public ImageSource imageSourceForImageControl(Bitmap yourBitmap)
    {
     ImageSourceConverter c = new ImageSourceConverter();
     return (ImageSource)c.ConvertFrom(yourBitmap);
    }
