        Point mDown;
        void imagemPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = e.Location;
        }
        void imagemPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(e.X + imagemPictureBox.Left - mDown.X, 
                                     e.Y + imagemPictureBox.Top - mDown.Y);
            }
        }
        void imagemPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = Point.Empty;
        }
