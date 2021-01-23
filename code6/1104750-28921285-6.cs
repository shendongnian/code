    private static void DrawInEllipse(PictureBox picBox, Image img, Rectangle rect)
    {
        picBox.Width = rect.Width - (int)(rect.Width*0.3f);
        picBox.Height = rect.Height - (int)(rect.Width * 0.3f);        
        picBox.Image = img;
        picBox.SizeMode = PictureBoxSizeMode.Zoom;
        picBox.BackColor = Color.Transparent;
        int picCenterX = (rect.Width - picBox.Width) / 2 + rect.Location.X;
        int picCenterY = (rect.Height - picBox.Height) / 2 + rect.Location.Y;
        picBox.Location = new System.Drawing.Point(picCenterX, picCenterY);
    }
