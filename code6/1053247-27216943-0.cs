        private Bitmap HourHand;
        private int HourDegree =45;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.RotateTransform(HourDegree);
            g.DrawImage(HourHand, new Point(0, 0));
        }
