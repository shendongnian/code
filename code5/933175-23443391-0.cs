    using (var path = new GraphicsPath())
    {  
       path.AddLines(myPoints);
       return path.IsOutlineVisible(pt, Pens.Black);
    }
