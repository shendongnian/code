     private void anyControl_MouseEnter(object sender, EventArgs e)
     {
           
        Control auxControl = (Control) sender;
            
        int enlargedWidth = (int) Math.Round(auxControl.Width * 1.20);
        int enlargedHeight = (int) Math.Round(auxControl.Height * 1.20);
        panel.Width = enlargedWidth;
        panel.Height = enlargedHeight;
        panel.Location = new Point (auxControl.Location.X - (int) Math.Round(auxControl.Width * 0.10), auxControl.Location.Y - (int) Math.Round(auxControl.Height * 0.10));
        Bitmap aBitmap = new System.Drawing.Bitmap(auxControl.Width, auxControl.Height);
        auxControl.DrawToBitmap(aBitmap, auxControl.ClientRectangle);
        Bitmap aZoomBitmap = ZoomImage(aBitmap, panel.Bounds);
        panel.ContentImage = aZoomBitmap;
        panel.Visible = true;
     }
  
     private Bitmap ZoomImage(Bitmap pBmp, Rectangle pDestineRectangle)
     {
            
        Bitmap aBmpZoom = new Bitmap(pDestineRectangle.Width, pDestineRectangle.Height);
        Graphics g = Graphics.FromImage(aBmpZoom);
        Rectangle srcRect = new Rectangle(0, 0, pBmp.Width, pBmp.Height);
        Rectangle dstRect = new Rectangle(0, 0, aBmpZoom.Width, aBmpZoom.Height);
        g.DrawImage(pBmp, dstRect, srcRect, GraphicsUnit.Pixel);
        return aBmpZoom;
     }
