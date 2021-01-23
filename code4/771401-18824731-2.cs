    private PathGeometry AddGeometries(
        Geometry geometry1, Geometry geometry2, double scale)
    {
        geometry2 = geometry2.Clone();
        geometry2.Transform = new ScaleTransform(scale, scale);
        var pathGeometry = PathGeometry.CreateFromGeometry(geometry1);
        pathGeometry.AddGeometry(geometry2);
        return pathGeometry;
    }
    private PathGeometry CombineGeometries(
        Geometry geometry1, Geometry geometry2, GeometryCombineMode mode, double scale)
    {
        geometry2 = geometry2.Clone();
        geometry2.Transform = new ScaleTransform(scale, scale);
        return Geometry.Combine(geometry1, geometry2, mode, null);
    }
