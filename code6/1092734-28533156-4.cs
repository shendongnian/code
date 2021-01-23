    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Track_t
    {
        public Track_t()
        {
            this.Track = new List<Trackpoint_t>();
        }
        [System.Xml.Serialization.XmlElement("TrackPoint", typeof(Trackpoint_t), IsNullable = false)]
        public List<Trackpoint_t> Track { get; set; }
    }
