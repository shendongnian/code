    bool drawRect = false;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if(drawRect)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Chocolate), mouseNewRect);
        }
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if(drawRect == false)
        {
            drawRect = true;
        }
            
        mouseNewRect = new Rectangle(new Point(e.X, e.Y), new Size(100, 100));
        this.Invalidate();
    }
    private void Form1_MouseLeave(object sender, EventArgs e)
    {
        //This will erase the rectangle when the mouse leaves Form1
        drawRect = false;
        this.Invalidate();
    }
