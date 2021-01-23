          List<Image> res = new List<Image>();
            int pembagiLebar = (int)Math.Ceil((float)img.Width / (float)blokX);
            int pembagiTinggi = (int)Math.Ceil((float)img.Height / (float)blokY);
            for (int i = 0; i < pembagiLebar ; i++)//baris
            {
                for (int j = 0; j < pembagiTinggi ; j++)//kolom
                {
                    Bitmap bmp = new Bitmap(blokX, blokY);
                    using (Graphics grp = Graphics.FromImage(bmp)) {
                         grp.DrawImage(img, 0, 0, new Rectangle(i * blokX, j * blokY, blokX, blokY), GraphicsUnit.Pixel);
                    }
                    
                    res.Add(bmp);
                }
            }
            return res;
