    private void Form2_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        using (Pen p = new Pen(Color.Black))
        {
            g.DrawLine(pen, 10, 10, 100, 100);
        }
    }
