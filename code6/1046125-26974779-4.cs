    public void CreateoneBppImageAndSave(String base64ImageString,String ImagePathToSave)
    {
        byte[] byteArray = Convert.FromBase64String(base64ImageString);
        
        using(Image img = byteArrayToImage(byteArray))
        using(Bitmap objBitmap = new Bitmap(img))
        {    
            BitmapData bmpData = objBitmap.LockBits(new Rectangle(0, 0, objBitmap.Width, objBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            try
            {
                using(Bitmap oneBppBitmap = new Bitmap(objBitmap.Width, objBitmap.Height, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0))
                {        
                    oneBppBitmap.Save(ImagePathToSave, ImageFormat.Bmp);
                }
            }
            finally
            {
                //put the unlock in a finally to make sure it happens.
                objBitmap.UnlockBits(bmpData);
            }
        }
    }
