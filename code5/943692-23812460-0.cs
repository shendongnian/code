    public static string GenerateBase64ImageString()
    {
        // 1. Create a bitmap
        using (Bitmap bitmap = new Bitmap(80, 20, PixelFormat.Format24bppRgb))
        {
            // 2. Get access to the raw bitmap data
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            // 3. Generate RGB noise and write it to the bitmap's buffer.
            // Note that we are assuming that data.Stride == 3 * data.Width for simplicity/brevity here.
            byte[] noise = new byte[data.Width * data.Height * 3];
            new Random().NextBytes(noise);
            Marshal.Copy(noise, 0, data.Scan0, noise.Length);
            bitmap.UnlockBits(data);
            // 4. Save as JPEG and convert to Base64
            using (MemoryStream jpegStream = new MemoryStream())
            {
                bitmap.Save(jpegStream, ImageFormat.Jpeg);
                return Convert.ToBase64String(jpegStream.ToArray());
            }
        }
    }
