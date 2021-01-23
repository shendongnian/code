    /// <summary>
    /// Creation of a LineString
    /// </summary>
    /// <param name="vectors"></param>
    /// <param name="_style"></param>
    /// <returns></returns>
    private Placemark CreateLineString(List<di_vector> vectors)
    {
        LineString linestring1 = new LineString();
        linestring1.AltitudeMode = AltitudeMode.Absolute;
        linestring1.Extrude = true;
        linestring1.Tessellate = true;
    
        CoordinateCollection coordinates = new CoordinateCollection();
        foreach (var item in vectors)
        {
            coordinates.Add(new SharpKml.Base.Vector(item.longitude,item.latitude));
        }
    
        linestring1.Coordinates = coordinates;
    
        Placemark placemark = new Placemark();
        placemark.Geometry = linestring1;
    
        return placemark;
    }
