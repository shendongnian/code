    // keep your data at class level:
    Point[] pts = { new Point(150, 12), new Point(130, 15), new Point(160, 18) };
    // all drawing in the paint event:
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using ( Pen Pen = new Pen(Color.Red, 3f) )
            e.Graphics.DrawLines( Pen, pts);
    }
    // trigger the drawing when needed, eg when you have added more points:
    private void button1_Click(object sender, EventArgs e)
    {
        // maybe add more points.. then trigger the paint event:
        this.Invalidate();
    }
