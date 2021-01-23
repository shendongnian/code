    public class Location
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
    
    public class Building : BaseEntity
    {
        public IEnumerable<Location> Location { get; set; }
    }
    
    public void CreateBuildingMapping()
    {
        var nodes = new List<Uri>() { ... };
        var connectionPool = new Elasticsearch.Net.ConnectionPool.SniffingConnectionPool(nodes);
        var connectionSettings = new Nest.ConnectionSettings(connectionPool, "myIndexName");
        var elasticsearchClient = new Nest.ElasticClient(connectionSettings);
        var putMappingDescriptor = new Nest.PutMappingDescriptor<Building>(connectionSettings);
        putMappingDescriptor.DateDetection(false);
        putMappingDescriptor.Dynamic(false);
        putMappingDescriptor.IncludeInAll(true);
        putMappingDescriptor.IgnoreConflicts(false);
        putMappingDescriptor.Index("myIndexName");
        putMappingDescriptor.MapFromAttributes();
        putMappingDescriptor
            .MapFromAttributes()
                .Properties(p =>
                    p.GeoPoint(s =>
                        s.Name(n => n.Location).IndexGeoHash().IndexLatLon().GeoHashPrecision(12)
                    )
                );
        putMappingDescriptor.NumericDetection(false);
        elasticsearchClient.Map(putMappingDescriptor);
    }
    
