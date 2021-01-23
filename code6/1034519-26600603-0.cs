            Bitmap b = new Bitmap(400, 400);
            Graphics g = Graphics.FromImage(b);
            g.PageUnit = GraphicsUnit.Point;
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Red, 1.2f);
            for (float i = 20f * pen.Width; i < 200f * pen.Width; i = i + 20f * pen.Width)
            {
                g.DrawLine(pen, 10f, i, 190f, i);
            }
            g.Dispose();
            b.Save("c:/temp/test.png", ImageFormat.Png);
            b.Dispose();
