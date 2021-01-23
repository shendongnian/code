    Color c;
    // Setup ARGB COLOR 80, 20, 86, 20
                c = Color.FromArgb(80, 20, 86, 20);
    
                int r, g, b, a;
    
                r = c.R;
                g = c.G;
                b = c.B;
                a = c.A;
    String rgba = String.Format("rgba({0},{1},{2},{3})", c.R, c.G, c.B, c.A);
