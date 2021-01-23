    byte siyah=0;  
        int dizisayisi;    
        IntPtr baslangic;  
        byte[] rgbdeger;  
        Bitmap resim;   
        Rectangle rct;  
        BitmapData bmData;   
        resim = new Bitmap(@"C:\YazilimGrubu.jpg");
        rct = new Rectangle(0, 0, resim.Width, resim.Height);
        bmData = resim.LockBits(rct, ImageLockMode.ReadWrite, resim.PixelFormat);
        baslangic = bmData.Scan0;
        dizisayisi = bmData.Stride * resim.Height;   
        rgbdeger = new byte[dizisayisi];   
        Marshal.Copy(baslangic, rgbdeger, 0, dizisayisi);
        for (int i = 2; i < rgbdeger.Length; i += 3)
        {
        siyah = (Byte)Math.Abs((Byte.Parse(rgbdeger[i - 2].ToString()) + Byte.Parse(rgbdeger[i - 1].ToString()) + Byte.Parse(rgbdeger[i].ToString())) / 3);
        rgbdeger[i - 2] = siyah;
        rgbdeger[i - 1] = siyah;
        rgbdeger[i] = siyah;
        }
        Marshal.Copy(rgbdeger, 0, baslangic, dizisayisi);
        resim.UnlockBits(bmData);
        pctResim.Image = resim;
