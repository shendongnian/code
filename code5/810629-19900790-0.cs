        private Point StartPoint;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                StartPoint = new Point(e.X, e.Y);
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                Point pt = pb.Location;
                pt.Offset(e.X - StartPoint.X, e.Y - StartPoint.Y);
                pb.Location = pt;
            }
        }
