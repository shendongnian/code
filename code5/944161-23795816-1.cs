    namespace Quoridor
    {
        public partial class Form1 : Form
        {       
            class RectangleAndPen
            {
                 public Rectangle Rectangle { get; set; }
                 public Pen Pen { get; set; }
            }
    
            List<RectangleAndPen> recList = new List<RectangleAndPen>();
    
            public Form1()
            {
                InitializeComponent();
    
                for (int x = 0; x < 12; x++)
                {
                    for (int y = 0; y < 12; y++)
                    {
                        recList.Add(new RectangleAndPen 
                                   { 
                                       Rectangle = new Rectangle(x * 50, y * 50, 100, 100),
                                       Pen = Pens.Black
                                   }
                    }
    
                    Application.DoEvents();
                }
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                foreach (RectangleAndPen r in recList)
                {                             
                    e.Graphics.DrawRectangle(r.Pen, r.Rectangle);
                }
    
            }
    
    
            private void Form1_Click(object sender, EventArgs e)
            {
                Point cursor = this.PointToClient(Cursor.Position);
    
                foreach (RectangleAndPen r in recList)
                {
                    if (r.Rectangle.Contains(cursor))
                    {
                        r.Pen = Pens.Red;
                    }
                }
    
                Invalidate();
            }
        }
    }
