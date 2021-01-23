    void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
                xUp = e.X;
                yUp = e.Y;
                Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
                using (Pen pen = new Pen(Color.YellowGreen, 3))
                {
                    pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
                }
                xDown = xDown * pictureBox1.Image.Width / pictureBox1.Width;
                yDown = yDown * pictureBox1.Image.Height / pictureBox1.Height;
                xUp = xUp * pictureBox1.Image.Width / pictureBox1.Width;
                yUp = yUp * pictureBox1.Image.Height / pictureBox1.Height;
                rectCropArea = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
        }
