    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using(Graphics g = e.Graphics)
        {
             Brush green = new SolidBrush(Color.Green);
             g.FillRectangle(green, rex, rey, 200, 20);
             // .. etc, etc..
        }
    }
