    public static void Save(this Texture2D texture, int width, int height, ImageFormat    imageFormat, string filename)
    {
        using (Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb))
        {
            byte blue;
            IntPtr safePtr;
            BitmapData bitmapData;
            Rectangle rect = new Rectangle(0, 0, width, height);
            byte[] textureData = new byte[4 * width * height];
            texture.GetData<byte>(textureData);
            for (int i = 0; i < textureData.Length; i += 4)
            {
                blue = textureData[i];
                textureData[i] = textureData[i + 2];
                textureData[i + 2] = blue;
            }
            bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            safePtr = bitmapData.Scan0;
            Marshal.Copy(textureData, 0, safePtr, textureData.Length);
            bitmap.UnlockBits(bitmapData);
            bitmap.Save(filename, imageFormat);
        }
    }
