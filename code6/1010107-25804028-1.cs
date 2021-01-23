    public ActionResult Image()
    {
        var bitmap = GetBitmap(); //Your method. Returns Bitmap
        var bitmapBytes = BitmapToBytes(bitmap); //Convert bitmap into a byte array
        return File(bitmapBytes, "image/jpeg"); //Return as file result
    }
    // This method is for converting bitmap into a byte array
    private static byte[] BitmapToBytes(Bitmap img)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
            byteArray = stream.ToArray();
        }
        return byteArray;
    }
