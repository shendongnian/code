    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Point[] pts = new Point[] { new Point(20, 20), 
                                        new Point(120, 20), 
                                        new Point(120, 50), 
                                        new Point(60, 50),        
                                        new Point(60, 70), 
                                        new Point(20, 70) };
    
            graphicsPath.AddPolygon(pts);
    
            e.Graphics.FillPath(Brushes.LightGreen, graphicsPath);
            e.Graphics.DrawPath(Pens.DarkGreen, graphicsPath);
        }
    }
