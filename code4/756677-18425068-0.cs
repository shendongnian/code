    public partial class Form1 : Form
    {
        private Graphics g;
        private readonly Pen pen;
        private Point oldCoords;
        private readonly GraphicsPath graphicsPaths = new GraphicsPath();
    
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            pen = new Pen(Color.Navy, 7);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (oldCoords.IsEmpty)
                    graphicsPaths.StartFigure();
                else
                {
                    graphicsPaths.AddLine(oldCoords, new Point(e.X, e.Y));
                    g.DrawPath(pen, graphicsPaths);
                }
                oldCoords= new Point(e.X,e.Y);
            }
            else
                oldCoords = Point.Empty;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawPath(pen, graphicsPaths);
        }
    }
