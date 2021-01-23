     private void Button_Click(object sender, EventArgs e)
     {
        string FontFamily = "Verdana";
        string fileName = "d:\\template.png";
        Size keyCardSize = new Size (1004, 638); // 170x108mm
        float Dpi = 150f;
        Bitmap bmp = new Bitmap(keyCardSize.Width, keyCardSize.Height);
        bmp.SetResolution(Dpi, Dpi);
        // test data:
        Bitmap photo = new Bitmap(@"D:\scrape\sousers\SOU_JonSkeet.jpeg");
        // I have measured the photo should be 30mm wide
        // so with 25.4mm to the inch we calculate a fitting dpi for it:  
        float photoDpi = photo.Width * 25.4f / 30f;
        photo.SetResolution(photoDpi , photoDpi );
        Font font1 = new Font(FontFamily, 23f);
        Font font2 = new Font(FontFamily, 12f);
        Font font3 = new Font(FontFamily, 14f);
        using (Graphics G = Graphics.FromImage(bmp))
        using (SolidBrush brush1 = new SolidBrush(Color.MediumVioletRed))
        using (SolidBrush brush2 = new SolidBrush(Color.Gray))
        {
            G.Clear(Color.White);
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.PageUnit = GraphicsUnit.Millimeter;
            G.SmoothingMode = SmoothingMode.HighQuality;
            StringFormat sf = StringFormat.GenericTypographic;
            int lBorder= 10;
            int rBorder= 160;
            int y1 = 10;
            int y2 = 25;
            //..
            int y4 = 60;
            //..
            //G.DrawImage(logo, imgLoc1);
            G.DrawImage(photo, new Point(lBorder, y4));
            //G.DrawImage(img3, imgLoc3);
            //G.DrawImage(img4, imgLoc4);
            //G.DrawImage(img5, imgLoc5);
           // test data:
            string txt1 = "Jon Skeet";
            string txt2 = "C Sharp Evangelist";
            //..
            SizeF s1 = G.MeasureString(txt1, font1, PointF.Empty, sf);
            SizeF s2 = G.MeasureString(txt2, font2, PointF.Empty, sf);
            //..
            G.DrawString(txt1, font1, brush1, new Point((int)(rBorder- s1.Width), y1));
            G.DrawString(txt2, font2, brush2, new Point((int)(rBorder- s2.Width), y2));
            //G.DrawString(txt3, font2, brush2, txtLoc3);
            //..
            //G.DrawString(txt7, font3, brush2, txtLoc7);
            G.FillRectangle(brush1, new RectangleF(rBorder - 1.5f, 52f, 1.5f, 46f));
      }
      bmp.Save(fileName, ImageFormat.Png);
      font1.Dispose();
      font2.Dispose();
      font3.Dispose();
      photo.Dispose();
      //..
    }
