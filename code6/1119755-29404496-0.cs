          List<Image> res = new List<Image>();
            int pembagiLebar = (int)Math.Ceil((float)img.Width / (float)blokX);
            int pembagiTinggi = (int)Math.Ceil((float)img.Height / (float)blokY);
            for (int i = 0; i < pembagiLebar ; i++)//baris
            {
                for (int j = 0; j < pembagiTinggi ; j++)//kolom
                {
                    Bitmap bmp = new Bitmap(blokX, blokY);
                    //Bitmap bmp = new Bitmap(img.Width, img.Height);
                    // fixed version from @blordbeard
                    res.Add(bmp);
                }
            }
            return res;
