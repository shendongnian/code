    using (Graphics G = panelCanvas.CreateGraphics() )
    {
        Rectangle R0 = new Rectangle(22,22,55,55); // your Rectangle!
        using (Bitmap bmp = new 
               Bitmap(panelCanvas.ClientSize.Width, panelCanvas.ClientSize.Height))
        {    panelCanvas.DrawToBitmap(bmp, panelCanvas.ClientRectangle);
             G.DrawImage(bmp, 111f, 111f, R0, GraphicsUnit.Pixel);
        }
    }
