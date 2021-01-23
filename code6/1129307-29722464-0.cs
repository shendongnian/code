    Bitmap bmp = new Bitmap(Panel.Width, Panel.Height);
            
    Panel.DrawToBitmap(bmp, new Rectangle(0, 0, Panel.Width, Panel.Height));
    
    Graphics grp = Graphics.FromImage(bmp);
                
    Pen selPen = new Pen(Color.Blue);
    grp.DrawRectangle(selPen, 10, 10, 50, 50);
    bmp.Save("d:\\check3.png", System.Drawing.Imaging.ImageFormat.Png);
