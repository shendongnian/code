     //1. Get the Bitmap
    BitmapDrawable drawable = imageView.GetDrawable();
    Bitmap bitmap = drawable.GetBitmap();
    
    //2. Compress the bitmap into a stream and use that to get the byte array
    byte[] imageData;
    using(MemoryStream stream = new MemoryStream())
    {
        bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
        imageData = stream.ToArray();
    }
