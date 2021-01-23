    public ISpatialReference CreateSpatialRefGCS(ESRI.ArcGIS.Geometry.esriSRGeoCSType gcsType)
    {
        ISpatialReferenceFactory spatialRefFactory = new SpatialReferenceEnvironmentClass();
        IGeographicCoordinateSystem geoCS = spatialRefFactory.CreateGeographicCoordinateSystem((int)gcsType);
        return (ISpatialReference)geoCS;
    }
    public IEnvelope GetExtent(IFeatureLayer PolygonLayer) {
        IEnvelope envelope = PolygonLayer.AreaOfInterest.Envelope;
        envelope.Project(CreateSpatialRefGCS(esriSRGeoCSType.esriSRGeoCS_WGS1984));
        return PolygonLayer.AreaOfInterest.Envelope;
    }
