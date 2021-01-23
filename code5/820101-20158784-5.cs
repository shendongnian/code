        public partial class Form1 : Form
        {
            int MouseClicksCount = 0;
            List<Region> regionList = new List<Region>();
    
            int EclipseX = 10;
            int EclipseY = 50;
            int BallWidth = 100;
            int BallHeight = 100;
            bool isfound=false;
            public Form1()
            {
                InitializeComponent();
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
                this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            }
    
            
    
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {       
                isfound=false;
                foreach(Region r in regionList)
                {
                if (r.IsVisible(e.X, e.Y))
                {
                    isfound=true;
                    break;
                }
                }
                if (isfound)
                    MouseClicksCount++;
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                SolidBrush brush = new SolidBrush(Color.Blue);           
                e.Graphics.FillEllipse(brush, EclipseX,EclipseY, BallWidth, BallHeight);
                regionList.Add(new Region(new Rectangle(EclipseX,EclipseY, BallWidth, BallHeight)));
            }
    
        }
