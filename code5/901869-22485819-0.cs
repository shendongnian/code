    public class MapPolicySnapshot
    {
        [JsonProperty("strMapPolicyID")]
        public long PolicyID { get; set; }
        
        [JsonProperty("lngLayerTypeID")]
        public long LayerTypeID { get; set; }
        
        [JsonProperty("lngSnapshotID")]
        public int SnapShotID { get; set; }
        
        [JsonProperty("intZoomLevel")]
        public int ZoomLevel { get; set; }
        
        [JsonProperty("strLayers")]
        public string Layers { get; set; }
        
        [JsonProperty("strDateChanged")]
        public string DateChanged { get; set; }
        
        [JsonProperty("strExtent")]
        public string Extent { get; set; }
    }
