    namespace YourAppNameSpaceHere
    {
        using Windows.Devices.Geolocation;
        public class SerializableGeoPoint
        {
            public SerializableGeoPoint(Geolocation location) 
                : this(location.Coordinate.Point) {}
            public SerializableGeoPoint(Geopoint point)
            {
                this.AltitudeReferenceSystem = point.AltitudeReferenceSystem;
                this.GeoshapeType = point.GeoshapeType;
                this.Position = point.Position;
                this.SpatialReferenceId = point.SpatialReferenceId;
            }
            public AltitudeReferenceSystem AltitudeReferenceSystem { get; set; }
            public GeoshapeType GeoshapeType { get; set; }
            public BasicGeoposition Position { get; set; }
            public uint SpatialReferenceId { get; set; }
            public Geopoint ToWindowsGeopoint()
            {
                return new Geopoint(Position, AltitudeReferenceSystem, SpatialReferenceId);
            }
        }
    }
