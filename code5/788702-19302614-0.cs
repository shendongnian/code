        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Rectangle rc = pictureBox1.Bounds;
            rc.Inflate(200, 200);
            pictureBox1.Bounds = rc;
            pictureBox1.BringToFront();
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Rectangle rc = pictureBox1.Bounds;
            rc.Inflate(-200, -200);
            pictureBox1.Bounds = rc;
        }
