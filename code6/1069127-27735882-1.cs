    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        // Clear picture box with blue color
        g.Clear(Color.Blue);
        // Create a pen to draw Ellipse
        Pen pen = new Pen(Color.Red);
        g.DrawEllipse(pen, 10, 10, 20, 20);
    }
