    private void Form1_Load(object sender, EventArgs e)
    {
        // No need to do that
        // pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e) {
        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 10, 20, 20));
    }
