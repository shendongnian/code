    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private class Class1
        {
            public int X1, X2, X3, X4;
        }
        private Class1 Mycl = new Class1();
        private Dictionary<int, Class1> MyDict = new Dictionary<int, Class1>();
        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Mycl.X1 = e.X;
                Mycl.X2 = e.Y;
                Mycl.X3 = e.X;
                Mycl.X4 = e.Y;
                Point pt1 = panel1.PointToScreen(new Point(Mycl.X1, Mycl.X2));
                Point pt2 = panel1.PointToScreen(new Point(Mycl.X3, Mycl.X4));
                ControlPaint.DrawReversibleLine(pt1, pt2, panel1.BackColor);
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point pt1 = panel1.PointToScreen(new Point(Mycl.X1, Mycl.X2));
                Point pt2 = panel1.PointToScreen(new Point(Mycl.X3, Mycl.X4));
                ControlPaint.DrawReversibleLine(pt1, pt2, panel1.BackColor);
                Mycl.X3 = e.X;
                Mycl.X4 = e.Y;
                pt2 = panel1.PointToScreen(new Point(Mycl.X3, Mycl.X4));
                ControlPaint.DrawReversibleLine(pt1, pt2, panel1.BackColor);
            }
        }
        private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Mycl.X3 = e.X;
                Mycl.X4 = e.Y;
                MyDict.Add(MyDict.Count + 1, Mycl);
                panel1.Invalidate();
                Mycl = new Class1();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen MyPen = new Pen(Color.Black))
            {
                foreach (KeyValuePair<int, Class1> kvp in MyDict)
                {
                    Point pl1 = new Point(kvp.Value.X1, kvp.Value.X2);
                    Point pl2 = new Point(kvp.Value.X3, kvp.Value.X4);
                    e.Graphics.DrawLine(MyPen, pl1, pl2);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(new Point(0,0), panel1.Size));
            bmp.Save(@"C:\Users\Mike\Pictures\SomeImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
