    public System.Windows.Point ToMercator(int test = 0)
    {
        System.Windows.Point mercator;
        double x = this.Longitude.ToMercator(test);
        double y = this.Latitude.ToMercator(test);
        mercator = new System.Windows.Point(x, y);
        return mercator;
    }
