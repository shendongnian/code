    var g = Graphics.FromImage(bitmap);
    g.ScaleTransform(10, 10);    
    using (pn = new Pen(Color.Wheat, -1)) {
        g.DrawLine(pn, 0, 0, 10, 10);
    }
