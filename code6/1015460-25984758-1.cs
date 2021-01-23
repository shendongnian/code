        var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), 
            ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
        var bytes = new byte[data.Height * data.Stride];
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        bytes[5 * data.Stride + 5] = 1; // Set the pixel at (5, 5) to the color #1
        Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
        image.UnlockBits(data);
