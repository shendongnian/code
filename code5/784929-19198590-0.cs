        List<Image> splitImages(int blockX, int blockY, Image img)
        {
            List<Image> res = new List<Image>();
            for (int i = 0; i < blockX; i++)
            {
                for (int j = 0; j < blockY; j++)
                {
                    Bitmap bmp = new Bitmap(img.Width / blockX, img.Height / blockY);
                    Graphics grp = Graphics.FromImage(bmp);
                    grp.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(i * bmp.Width, j * bmp.Height, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                    res.Add(bmp);
                }
            }
            return res;
        }
        private void testButton_Click_1(object sender, EventArgs e)
        {
            // Test for 4x4 Blocks
            List<Image> imgs = splitImages(4, 4, pictureBox1.Image);
            pictureBox2.Image = imgs[0];
            pictureBox3.Image = imgs[1];
            pictureBox4.Image = imgs[2];
            pictureBox5.Image = imgs[3];
        }
