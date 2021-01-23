    namespace DrawingText
    {
        public partial class Form1 : Form
        {
            private Point mouseDownPosition = new Point(0, 0);
            private Point mouseMovePosition = new Point(0, 0);
            private int mousePressdDown;
            private ArrayList drawnItemsList;
            Random rnd;
            public Form1()
            {
                InitializeComponent();
                drawnItemsList = new ArrayList();
                this.rnd = new Random();
            }
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                if (mousePressdDown == 1)
                {
                    label1.Text = "X: " + mouseMovePosition.X.ToString();
                    label2.Text = "Y: " + mouseMovePosition.Y.ToString();
                    this.Invalidate();
                }
                DrawingData a = new DrawingData(mouseMovePosition, mouseDownPosition, rnd.Next().ToString());
                drawnItemsList.Add(a);
                mousePressdDown = 0;
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                foreach (DrawingData a in drawnItemsList)
                {
                    draw(e.Graphics, a);
                }
                draw(e.Graphics, mouseDownPosition, mouseMovePosition);
            }
        
            private void draw(Graphics e, DrawingPoint a)
            {
                Pen p = new Pen(Color.Black, 2);
                using (Font useFont = new Font("Gotham Medium", 28, FontStyle.Bold))
                {
                    RectangleF header2Rect = new RectangleF();
                    int moldX = a.old.X - 5;
                    int moldY = a.old.Y;
                    header2Rect.Location = new Point(moldX, moldY);
                    header2Rect.Size = new Size(600, ((int)e.MeasureString(header2, useFont, 600, StringFormat.GenericTypographic).Height));
                    e.DrawString(a.Rand, useFont, Brushes.Black, header2Rect);
                }
            }
        }
    }
