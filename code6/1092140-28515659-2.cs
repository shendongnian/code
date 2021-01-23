    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Opacity = 0.1f;
            // a color that will allow using the mouse on the form:
            BackColor = Color.GreenYellow;
            TransparencyKey = BackColor;
        }
        Point mDown = Point.Empty;
        Point mCur = Point.Empty;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = e.Location;
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = Point.Empty;
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            mCur = e.Location;
            Invalidate();
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
           if (mDown == Point.Empty) return;
           Size s = new System.Drawing.Size(Math.Abs(mDown.X - mCur.X),
                                            Math.Abs(mDown.Y - mCur.Y)  );
           Point topLeft = new Point(Math.Min(mDown.X, mCur.X), 
                                     Math.Min(mDown.Y, mCur.Y));
           Rectangle r = new Rectangle(topLeft, s);
           e.Graphics.Clear(this.BackColor);            // <--- necessary!
           e.Graphics.FillRectangle(Brushes.Bisque, r );   // <--- pick your..
           e.Graphics.DrawRectangle(Pens.Red, r);    // <--- colors!
        }
    }
}
