    for (int i = 0; i < 6; i++)
    {
       string bitmapName = "bg" + i;
       bmp = Properties.Resources.ResourceManager.GetObject(bitmapName) as Bitmap;
       if(bmp != null)
           bmp.Save("C:\\Users/Chance Leachman/Desktop/bg" + i + ".bmp");
    }
