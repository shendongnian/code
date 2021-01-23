    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;            
        using (Pen p = new Pen(Brushes.Red))
        {
            g.DrawLine(p, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }
    }
