        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Right now I am using right click as a call to blur
            if (e.Button == MouseButtons.Right)
            {
                if (Rect.Contains(e.Location))
                {
                    pictureBox1.Image = Blur(getPictureBoxImage(), Rect, 5);
                    pictureBox1.Refresh();
                }
            }
        }
        private Bitmap getPictureBoxImage()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(pictureBox1.Image,
                    new Rectangle(0, 0, bmp.Width, bmp.Height));
            }
            return bmp;
        }
