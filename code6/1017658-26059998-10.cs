    [XmlRoot("AlertInfo")]
    public class AlertInfo
    {
        [XmlElement("TargetID")]
        public string strTargetId { get; set; }
        [XmlElement("ChannelID")]
        public string strChId { get; set; }
        [XmlElement("Timestamp")]
        public string strTimestamp { get; set; }
        [XmlElement("Object")]
        public RectObject rfObject { get; set; }
        [XmlIgnore]
        public List<List<PointF[]>> lstPolygons { get; set; }
        [XmlArray("Polygons")]
        [XmlArrayItem("Polygon")]
        public List<Polygon> Polygons
        {
            get {
                return lstPolygons.Select(p => new Polygon() { Points = p.SelectMany(lp => lp).ToList() }).ToList();
            }
        }
    }
