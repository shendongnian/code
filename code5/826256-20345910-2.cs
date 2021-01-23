    public class PictureBoxX : PictureBox
    {
        static PropertyInfo ImageRectangle;
        static PictureBoxX() {
            ImageRectangle = typeof(PictureBox).GetProperty("ImageRectangle",
                              BindingFlags.NonPublic | BindingFlags.Instance);
        }        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x202 || m.Msg == 0x201) {
                var imageRect = (Rectangle)ImageRectangle.GetValue(this, null);
                using (var bm = new Bitmap(imageRect.Width, imageRect.Height,
                             System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
                using(var g = Graphics.FromImage(bm)) {
                    int x = (int) (m.LParam.ToInt64() & 0xffff) - imageRect.X;
                    int y = (int) (m.LParam.ToInt64() >> 16) - imageRect.Y;
                    var rect = imageRect;
                    rect.Location = Point.Empty;
                    g.DrawImage(Image, rect);
                    if (!imageRect.Contains(x, y)) return;
                    else {
                        Color c = bm.GetPixel(x, y); 
                        //I choose the threshold 30 for the alpha channel
                        //the ideal threshold is 0, it's up to you.
                        if (c.A < 30) return;
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
