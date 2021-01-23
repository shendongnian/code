     private void button1_Click(object sender, EventArgs e)
            {
               
                    Form2 Plot = new Form2(new Point2D(10, 10), new Point2D(100, 100));
                    Plot.ShowDialog();
               
            }
     public partial class Form2 : Form
        {
            private Point2D _originalVector;
            private Point2D _rotatedVector;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            public Form2(Point2D OriginalVector, Point2D RotatedVector)
            {
                InitializeComponent();
    
                _originalVector = OriginalVector;
                _rotatedVector = RotatedVector;
            }
    
            private void userControl11_Paint(object sender, PaintEventArgs e)
            {
                                    using (Graphics g = e.Graphics)
                    {
                        GraphicsContainer container = g.BeginContainer(
                              new RectangleF(0f, 0f, 300f, 300f)
                            , new RectangleF(0f, 0f, 300f, 300f)
                            , GraphicsUnit.Pixel);
                        g.FillRectangle(new SolidBrush(Color.White), new RectangleF(0f, 0f, 300f, 350f));
                        g.DrawLine(new Pen(Color.Gray), 150f, 0f, 150f, 300f);
                        g.DrawLine(new Pen(Color.Gray), 0f, 150f, 300f, 150f);
    
                        float xOrigVect = (float)_originalVector.X;
                        float yOrigVect = (float)_originalVector.Y;
                        float xRotVect = (float)_rotatedVector.X;
                        float yRotVect = (float)_rotatedVector.Y;
    
                        xOrigVect = 150f + xOrigVect;
                        yOrigVect = 150f - yOrigVect;
                        xRotVect = 150f + xRotVect;
                        yRotVect = 150f - yRotVect;
    
                        g.DrawLine(new Pen(Color.Blue, 2f), 150f, 150f, xOrigVect, yOrigVect);
                        g.DrawLine(new Pen(Color.Red, 2f), 150f, 150f, xRotVect, yRotVect);
    
                        g.DrawString("Legenda: ", new System.Drawing.Font("sans-serif", 8.0f), Brushes.Black, new PointF(0f, 310f));
                        g.DrawLine(new Pen(Color.Blue, 2f), 0f, 330f, 10f, 330f);
                        g.DrawString("Vetor original", new System.Drawing.Font("sans-serif", 8.0f), Brushes.Black, new PointF(10f, 322f));
                        g.DrawLine(new Pen(Color.Red, 2f), 0f, 340f, 10f, 340f);
                        g.DrawString("Vetor rotacionado", new System.Drawing.Font("sans-serif", 8.0f), Brushes.Black, new PointF(10f, 332f));
                        g.EndContainer(container);
                    }
              
            }
        }
