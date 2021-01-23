    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                
    g.DrawImage(source,
                new System.Drawing.Rectangle(0, 0, target.Width, target.Height),
                cropRect,
                GraphicsUnit.Pixel);
