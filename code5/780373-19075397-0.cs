    public partial class UserControl1 : Panel
    {
        public UserControl1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;
        }
    
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Black);
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
