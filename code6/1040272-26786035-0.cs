    public void UpdatePixelIndexes(IEnumerable<byte[]> lineIndexes)
    {
        int width = this.Image.Width;
        int height = this.Image.Height;
        int rowIndex = 0;
        BitmapData data = this.Image.LockBits(Rectangle.FromLTRB(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
        try
        {
            foreach (byte[] scanLine in lineIndexes)
            {
                Marshal.Copy(scanLine, 0,
                   IntPtr.Add(data.Scan0, data.Stride * rowIndex), width);
                if (++rowIndex >= height)
                {
                    break;
                }
            }
        }
        finally
        {
            this.Image.UnlockBits(data);
        }
    }
