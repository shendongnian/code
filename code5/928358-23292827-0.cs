    private void groupBox_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics; //this.CreateGraphics();
        Brush b = new SolidBrush(Color.Gray);
        g.FillRectangle(b, 800, 70, 360, 440);
        groupBox.Invalidate();
    }
