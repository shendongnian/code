    Image resizeImg(Image img, int width)
        {
            // 4:3 Aspect Ratio. You can also add it as parameters
            double aspectRatio_X = 4;
            double aspectRatio_Y = 3;                        
            double targetHeight = Convert.ToDouble(width) / (aspectRatio_X / aspectRatio_Y);
            img = cropImg(img);
            Bitmap bmp = new Bitmap(width, (int)targetHeight);
            Graphics grp = Graphics.FromImage(bmp);
            grp.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            return (Image)bmp;
        }
        Image cropImg(Image img)
        {
            // 4:3 Aspect Ratio. You can also add it as parameters
            double aspectRatio_X = 4;
            double aspectRatio_Y = 3;
            double imgWidth = Convert.ToDouble(img.Width);
            double imgHeight = Convert.ToDouble(img.Height);
            if (imgWidth / imgHeight > (aspectRatio_X / aspectRatio_Y))
            {
                double extraWidth = imgWidth - (imgHeight * (aspectRatio_X / aspectRatio_Y));
                double cropStartFrom = extraWidth / 2;
                Bitmap bmp = new Bitmap((int)(img.Width - extraWidth), img.Height);
                Graphics grp = Graphics.FromImage(bmp);                                                
                grp.DrawImage(img, new Rectangle(0, 0, (int)(img.Width - extraWidth), img.Height), new Rectangle((int)cropStartFrom, 0, (int)(imgWidth - extraWidth), img.Height), GraphicsUnit.Pixel);
                return (Image)bmp;
            }
            else
                return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = resizeImg(pictureBox1.Image, 60);
        }
