    Bitmap bitmap = new Bitmap(800, 110);
    
    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
    using (Font font1 = new Font("Arial", 120, FontStyle.Regular, GraphicsUnit.Pixel))
    {
       Rectangle rect1 = new Rectangle(0, 0, 800, 110);
    
       StringFormat stringFormat = new StringFormat();
       stringFormat.Alignment = StringAlignment.Center;
       stringFormat.LineAlignment = StringAlignment.Center;
       graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    
       Font goodFont = FindFont(graphics, "Billy Reallylonglastnameinstein", rect1.Size, font1);
       graphics.DrawString(
          "Billy Reallylonglastnameinstein",
          goodFont,
          Brushes.Red,
          rect1,
          stringFormat
       );
    }
