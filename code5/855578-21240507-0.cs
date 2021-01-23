    // Initialize some dimensions
    int x = pictureBox1.Bounds.X;
    int y = pictureBox1.Bounds.Y;
    int w = Math.Min(pictureBox1.Bounds.Width, pictureBox1.Bounds.Height);
    int h = w;    // Force square
    int centerX = w / 2;
    int centerY = h / 2;
    float radius = w - centerX;
    Graphics g = pictureBox1.CreateGraphics();
    // First time draw a solid background then
    // each successive time cover with semi-transparent background
    Brush backGround = firstTime ? new SolidBrush(Color.FromArgb(255, 0, 0, 0)) : new SolidBrush(Color.FromArgb(10, 0, 0, 0));
    firstTime = false;
    g.FillEllipse(backGround, 0, 0, w, h);
    float lineX = (float)(centerX + (radius * Math.Sin(anglecounter * (Math.PI / 180))));
    float lineY = (float)(centerX + (radius * Math.Cos(anglecounter * (Math.PI / 180))));
    anglecounter -= 1;
    g.DrawLine(new Pen(Color.Green, 3), centerX, centerY, lineX, lineY);
    g.DrawArc(new Pen(Color.Red, 4), new Rectangle(0, 0, w - 1, h - 1), 0, 360);
