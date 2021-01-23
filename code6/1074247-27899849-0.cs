            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, new Rectangle(0,0,pictureBox1.Width, pictureBox1.Height));
            pictureBox2.DrawToBitmap(bmp, new Rectangle(pictureBox2.Location.X - pictureBox1.Location.X, pictureBox2.Location.Y - pictureBox1.Location.Y, pictureBox2.Width, pictureBox2.Height));
            pictureBox3.DrawToBitmap(bmp, new Rectangle(pictureBox3.Location.X - pictureBox1.Location.X, pictureBox3.Location.Y - pictureBox1.Location.Y, pictureBox3.Width, pictureBox3.Height));
            bmp.Save(@"C:\Temp\output.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
