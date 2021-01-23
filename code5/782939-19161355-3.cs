        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.ClientRectangle, GraphicsUnit.Pixel);
            Color top = Color.FromArgb(128, Color.Blue);
            Color bottom = Color.FromArgb(128, Color.Red);
            LinearGradientMode direction = LinearGradientMode.Vertical;
            LinearGradientBrush brush = new LinearGradientBrush(pictureBox1.ClientRectangle, top, bottom, direction);
            e.Graphics.FillRectangle(brush, pictureBox1.ClientRectangle);
        }
