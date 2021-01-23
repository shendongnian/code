        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                ReleaseInUseResource();
                using (Bitmap bmp = new Bitmap(open.FileName))
                {
                    bmp.Save(@"frame.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                pictureBox1.Image = Bitmap.FromFile(@"frame.jpeg");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"frame.jpeg"))
            {
                ReleaseInUseResource();
                pictureBox1.Image = new Bitmap(@"frame.jpeg");
            }
            else
            {
                pictureBox1.BackColor = Color.Black; //Blank
            }
        }
        private void ReleaseInUseResource()
        {
            Image img = pictureBox1.Image;  // Get image used to display in picture box.
            if (img != null) img.Dispose(); // release it first if there is an image opened.
        }
