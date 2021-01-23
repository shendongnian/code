    using System.Drawing;
    using System.Drawimg.Imaging;
    ...
    // Original image to be transformed
    var src = Image.FromFile(@"c:\temp\test.png");
    // Destination image to receive the transformation
    var dest = new Bitmap(src.Width, src.Height, PixelFormat.32bppArgb);
    using (var g = Graphics.FromImage(dest))
    {
        var attr = new ImageAttributes();
        float[][] matElements = {
            new float[] { 0.0f, 0.0f, 0.0f, 0.5f, 0.0f },
            new float[] { 0.0f, -1.0f, 0.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 0.0f,  0.0f, 0.0f, 0.0f },
            new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 1.0f }
        };
        
        attr.SetColorMatrix(new ColorMatrix(matElements), ColorMatrixFlag.Default,
            ColorAdjustType.Bitmap);
        g.DrawImage(src, new Rectangle(0, 0, src.Width, src.Height), 0, 0,
            src.Width, src.Height, GraphicsUnit.Pixel, attr);
    }
