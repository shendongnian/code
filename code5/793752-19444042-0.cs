    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DoubleBuffered = true;
            }
    
            Rectangle myBox = new Rectangle(0, 0, 30, 30);
            Point mouseDownPos = Point.Empty;
            bool allowMove = false;
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
    
                if (!myBox.Contains(e.Location))
                    return;
    
                mouseDownPos = new Point(e.Location.X - myBox.Left, e.Location.Y - myBox.Top);
    
                allowMove = true;
            }
    
            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
    
                allowMove = false;
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (!allowMove)
                    return;
    
                myBox.Location = new Point(e.Location.X - mouseDownPos.X, e.Location.Y - mouseDownPos.Y);
    
                Invalidate();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                e.Graphics.FillRectangle(Brushes.Aquamarine, myBox);
            }
        }
