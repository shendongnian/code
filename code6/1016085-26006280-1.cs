    public Form1()
        {
            InitializeComponent();
            myPen = new Pen(Brushes.Red, 2);
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g;
            using (g = Graphics.FromImage(img))
            {
                g.DrawImage(imageOfPicturebox, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            imgClone = (Bitmap)img.Clone();
            pictureBox1.Image = img;
        }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location != RectStartPoint)
            {
                DrawRectangle(e.Location);
            }
        }
        private void DrawRectangle(Point pnt)
        {
            Graphics g = Graphics.FromImage(img);
            int width, height, i, x;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(imgClone, 0, 0);
            if (pnt.X == RectStartPoint.X || pnt.Y == RectStartPoint.Y)
            {
                g.DrawLine(myPen, RectStartPoint.X, RectStartPoint.Y, pnt.X, pnt.Y);
            }
            else
            {
                g.DrawRectangle(myPen, Math.Min(RectStartPoint.X, pnt.X), Math.Min(RectStartPoint.Y, pnt.Y),
                                Math.Abs(RectStartPoint.X - pnt.X), Math.Abs(RectStartPoint.Y - pnt.Y));
                
                width = (int)((Math.Abs(RectStartPoint.X - pnt.X)) / (n - 1));
                height = (int)((Math.Abs(RectStartPoint.Y - pnt.Y)) / (n - 1));
                x = Math.Min(RectStartPoint.X, pnt.X);
                for (i = 0; i < n - 1; i++) //up side
                {
                    g.FillEllipse(Brushes.Green, new Rectangle(x - 3, Math.Min(RectStartPoint.Y, pnt.Y) - 3, 6, 6));
                    x += width;
                }
                g.FillEllipse(Brushes.Green, new Rectangle(Math.Min(RectStartPoint.X, pnt.X) + Math.Abs(RectStartPoint.X - pnt.X) - 3, 
                              Math.Min(RectStartPoint.Y, pnt.Y) - 3, 6, 6));
                //same approach as above for left, right and bottom side
                ...
            }
            g.Dispose();
            
            pictureBox1.Invalidate();
        }
