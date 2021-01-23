    using System.Drawing;
    using System.Drawing.Drawing2D;
    
    private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
    {
        Bitmap result = new Bitmap(nWidth, nHeight);
        using (Graphics g = Graphics.FromImage((Image)result))
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(b, 0, 0, nWidth, nHeight);
        }
        return result;
    }
