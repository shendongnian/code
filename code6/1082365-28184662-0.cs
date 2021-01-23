    public partial class Form1 : Form
    {
        public bool flag = false;
        public bool f = false;
        Bitmap panelImage;
        Point previousPoint;
    
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            panelImage = new Bitmap(mainPanel.Width, mainPanel.Height);
        }
    
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(panelImage, new Point());
        }
        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
            flag = true;
        }        
        private void drawLine(Point start, Point end)
        {
            using (Graphics g = Graphics.FromImage(mainPanel))
            using (Pen pen = new Pen(Colors.Black, 10))
            {
                g.DrawLine(pen, start, end);
            }
        }
        private void mainPanel_Up(object sender, MouseEventArgs e)
        {
            flag = false;
        }
        private void mainPanel_move(object sender, MouseEventArgs e)
        {
           if(flag){
            drawLine(previousPoint, e.Location);
            previousPoint = e.Location;
          }
        }
    }
