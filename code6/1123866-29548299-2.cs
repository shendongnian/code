    namespace YourAppNameSpaceHere
    {
        using Windows.Devices.Geolocation;
        public class SerializableGeoPoint
        {
            public SerializableGeoPoint(Geoposition location) 
                : this(location.Coordinate.Point) {}
            public SerializableGeoPoint(Geopoint point)
            {
                this.AltitudeReferenceSystem = point.AltitudeReferenceSystem;
                this.GeoshapeType = point.GeoshapeType;
                this.Position = point.Position;
                this.SpatialReferenceId = point.SpatialReferenceId;
            }
            [JsonConverter(typeof(StringEnumConverter))]
            public AltitudeReferenceSystem AltitudeReferenceSystem { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public GeoshapeType GeoshapeType { get; set; }
            
            [JsonProperty]
            public BasicGeoposition Position { get; set; }
            [JsonProperty]
            public uint SpatialReferenceId { get; set; }
            public Geopoint ToWindowsGeopoint()
            {
                return new Geopoint(Position, AltitudeReferenceSystem, SpatialReferenceId);
            }
        }
    }
