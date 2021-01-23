    private void button2_Click(object sender, EventArgs e)
    {
            Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
            int x1 = 0;
            int x2 = Math.Max(pictureBox1.Image.Width, pictureBox3.Image.Width);
            int y1 = 0;
            int y2 = Math.Max(pictureBox1.Image.Height, pictureBox2.Image.Height);
            Rectangle rect1 = new Rectangle(new Point(x1, y1), pictureBox1.Image.Size);
            Rectangle rect2 = new Rectangle(new Point(x2, y1), pictureBox2.Image.Size);
            Rectangle rect3 = new Rectangle(new Point(x1, y2), pictureBox3.Image.Size);
            Rectangle rect4 = new Rectangle(new Point(x2, y2), pictureBox4.Image.Size);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.DrawImage(pictureBox1.Image, rect1);
                G.DrawImage(pictureBox2.Image, rect2);
                G.DrawImage(pictureBox3.Image, rect3);
                G.DrawImage(pictureBox4.Image, rect4);
            }
            bmp.Save("d:\\foursome2jpg", ImageFormat.Jpeg);
           // and clean up:
           bmp.Dispose();
    }
