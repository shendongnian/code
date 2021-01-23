    double a=0.0, b=0.0;
    Geometry g = new Geometry();
    Double.TryParse("2.5", out a);
    Double.TryParse("ADFBBG", out b);
    Geometry.TryParse("M150,0L75,200 225,200z", out g);
