    public static double MetersToPixels(double meters, double latitude, double zoomLevel)
    {
        var pixels = meters / (156543.04 * Math.Cos(Math.PI / 180 * latitude) / (Math.Pow(2, zoomLevel)));
        return Math.Abs(pixels);
    }
