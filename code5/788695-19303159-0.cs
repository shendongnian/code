    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Red, 1))
        {
            foreach (Rectangle r in DrawBuffer)
            {
                e.Graphics.DrawRectangle(pen, r);
            }
        }
    }
