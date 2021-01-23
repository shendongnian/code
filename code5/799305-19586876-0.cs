    var data = mypic.LockBits(
        new Rectangle(Point.Empty, mypic.Size),
        ImageLockMode.ReadWrite, mypic.PixelFormat);
    var pixelSize = data.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3; // only works with 32 or 24 pixel-size bitmap!
    var padding = data.Stride - (data.Width * pixelSize);
    var bytes = new byte[data.Height * data.Stride];
    // copy the bytes from bitmap to array
    Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
    var index = 0;
    var builder = new StringBuilder();
    for (var y = 0; y < data.Height; y++)
    {
        for (var x = 0; x < data.Width; x++)
        {
            Color pixelColor = Color.FromArgb(
                pixelSize == 3 ? 255 : bytes[index + 3], // A component if present
                bytes[index + 2], // R component
                bytes[index + 1], // G component
                bytes[index]      // B component
                );
            builder
                .Append("  ")
                .Append(pixelColor.R)
                .Append("     ")
                .Append(pixelColor.G)
                .Append("     ")
                .Append(pixelColor.B)
                .Append("     ")
                .Append(pixelColor.A)
                .AppendLine();
            index += pixelSize;
        }
        index += padding;
    }
    // copy back the bytes from array to the bitmap
    Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
    textBox2.Text = builder.ToString();
