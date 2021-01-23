    public PointF GeoCoordToPixel(IGeographicPosition geoPos)
    {
        double tempLong = geoPos.Longitude;
        if (tempLong > CenterPos.Longitude && (tempLong - CenterPos.Longitude) > 180)
        {
            // the position is to the left, over the antimeridian
            tempLong = tempLong - 360;
        }
        if (tempLong < CenterPos.Longitude && (CenterPos.Longitude - tempLong) > 180)
        {
            // the position is to the right, over the antimeridian
            tempLong = tempLong + 360;
        }
        PointF pt = new PointF(
            (float)((tempLong - LongitudeOfOrigin) / LongitudeIncrement),
            (float)((-geoPos.Latitude + LatitudeOfOrigin) / LatitudeIncrement));
        return pt;
    }
