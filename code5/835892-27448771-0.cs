    public class ImageBlur :   AbstractProcessing
    {
        Graphics g = Graphics.FromImage(imageBlur);
            g.CompositingMode = CompositingMode.SourceCopy;
            //image.MakeTransparent();
            int x = (imageBlur.Width - image.Width) / 2;
            int y = (imageBlur.Height - image.Height) / 2;
            g.DrawImage(image, new Point(x, y));
            return imageBlur;
    }
}
