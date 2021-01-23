    public System.Windows.Point ToMercator(int test = 0)
    {
        System.Windows.Point mercator;
        double x = this.Latitude.ToMercator(test);
        double y = this.Longitude.ToMercator(test);
        mercator = new System.Windows.Point(x, y);
        return mercator;
    }
