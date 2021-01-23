    private static byte[] DecodeBinaryFromBitmap(Stream inputStream)
    {
        using (Bitmap bitmap = (Bitmap)Image.FromStream(inputStream))
        {
            int length = bitmap.GetPixel(0, 0).ToArgb();
            byte[] buffer = new byte[length];
            int x = 1, y = 0;
            for (var offset = 0; offset < buffer.Length; offset += 4)
            {
                var colorValue = bitmap.GetPixel(x, y);
                byte[] pixelBuffer = BitConverter.GetBytes(colorValue.ToArgb());
                Array.Copy(pixelBuffer, 0, buffer, offset, Math.Min(4, buffer.Length - offset));
                x++;
                if (x >= bitmap.Width)
                {
                    x = 0;
                    y++;
                }
            }
            return buffer;
        }
    }
