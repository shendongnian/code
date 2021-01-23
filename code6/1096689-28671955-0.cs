    float pbZoom = 3f;  // the factor by which the PictureBox is zoomed in or out
    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
    pictureBox.ClientSize = new Size((int)(pictureBox.Image.Width * pbZoom),
             (int)(pictureBox.Image.Height * pbZoom));
    pictureBox.Paint     += pictureBox_Paint;
    pictureBox.MouseDown += pictureBox_MouseDown;
    pictureBox.MouseMove += pictureBox_MouseMove;
    pictureBox.MouseUp   += pictureBox_MouseUp;
