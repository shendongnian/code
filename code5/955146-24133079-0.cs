    public LocationRectangle GetVisibleMapArea(Map mMap)
    {
        GeoCoordinate mCenter = mMap.Center;
        Point pCenter = mMap.ConvertGeoCoordinateToViewportPoint(mCenter);
        GeoCoordinate topLeft = MapVieMode.ConvertViewportPointToGeoCoordinate(new Point(0, 0));
        GeoCoordinate bottomRight = MapVieMode.ConvertViewportPointToGeoCoordinate(new Point(MapVieMode.ActualWidth, MapVieMode.ActualHeight));
    
        if (topLeft != null && bottomRight != null)
        {
            Point pNW = new Point(pCenter.X - mMap.ActualWidth / 2, pCenter.Y - mMap.ActualHeight / 2);
            Point pSE = new Point(pCenter.X + mMap.ActualWidth / 2, pCenter.Y + mMap.ActualHeight / 2);
            if (pNW != null && pSE != null)
            {
                GeoCoordinate gcNW = mMap.ConvertViewportPointToGeoCoordinate(pNW);
                GeoCoordinate gcSE = mMap.ConvertViewportPointToGeoCoordinate(pSE);
                return new LocationRectangle(gcNW, gcSE);
            }
        }
    
        return null;
    }
