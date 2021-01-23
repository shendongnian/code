    public class Message
    {
        // Notifications
        public string Title { get; set; }
        public string Content { get; set; }
        public int zoneCount { get; set; }
    
        public string CntrX { get; set; }
        public string CntrY { get; set; }
    
        // Polygon Overlays
        public List<string>  PointList {get; set;}
    }
