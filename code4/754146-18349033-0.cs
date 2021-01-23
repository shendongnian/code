    Image DrawText(string text, Font font, Color textColor, Color backColor) {
        Size textSize;
        using(Image tmp = new Bitmap(1, 1)) {
            using(Graphics g = Graphics.FromImage(tmp)) {
                textSize = Size.Ceiling(g.MeasureString(text, font));
            }
        }
        Bitmap bitmap = new Bitmap(textSize.Width, textSize.Height);
        using(Graphics g = Graphics.FromImage(bitmap)) {
            g.Clear(backColor);
            using(Brush textBrush = new SolidBrush(textColor)) {
                g.DrawString(text, font, textBrush, 0, 0);
            }
        }
        const double Distortion = 2.0;
        const double F = Math.PI / 64.0;
        using(Bitmap copy = bitmap.Clone() as Bitmap) {
            for(int y = 0; y < textSize.Height; y++) {
                for(int x = 0; x < textSize.Width; x++) {
                    int newX = (int)(x + Distortion * Math.Sin(F * y));
                    int newY = (int)(y + Distortion * Math.Cos(F * x));
                    if(newX < 0 || newX >= textSize.Width) newX = 0;
                    if(newY < 0 || newY >= textSize.Height) newY = 0;
                    bitmap.SetPixel(x, y, copy.GetPixel(newX, newY));
                }
            }
        }
        return bitmap;
    }
