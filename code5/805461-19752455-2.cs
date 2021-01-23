    double a=0.0, b=0.0;
    Geometry g = new Geometry();
    
    try
    {
       a = Double.Parse("2.5");
       b = Double.Parse("ADFBBG");
       g = Geometry.Parse("M150,0L75,200 225,200z");
    }
    catch
    {
        //At least mark that conversion was not succesful
    }
