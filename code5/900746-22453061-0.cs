    private void pictureBox_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(pictureBox.Image, 0, 0, 
            pictureBox.ClientRectangle, GraphicsUnit.Pixel);
        Color left = Color.FromArgb(128, Color.Blue);
        Color right = Color.FromArgb(128, Color.Red);
        LinearGradientMode direction = LinearGradientMode.Horizontal;
        LinearGradientBrush brush = new LinearGradientBrush(
            pictureBox.ClientRectangle, left, right, direction);
        e.Graphics.FillRectangle(brush, pictureBox.ClientRectangle);
    }
