    Image a = ...;
    Image b = ...;
    //assuming equal height, and I forget whether the ctor is width first or height first
    Image c = new Image(a.Width + b.Width, a.Height);
    Graphics g = Graphics.FromImage(c);
    g.DrawImage(...); //a lot of overloads, better check out the documentation
    SaveImage(c); //depending on how you want to save it
    g.Dispose();
