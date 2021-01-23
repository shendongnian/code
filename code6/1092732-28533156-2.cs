    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")
    ]
    public partial class ActivityLap_t
    {
        private List<Track_t> _track;  // Change type to `Track_t`
        public ActivityLap_t()
        {
            this._extensions = new Extensions_t();
            this._track = new List<Track_t>(); // Change type to `Track_t`
            this._maximumHeartRateBpm = new HeartRateInBeatsPerMinute_t();
            this._averageHeartRateBpm = new HeartRateInBeatsPerMinute_t();
        }
        // Change type to `Track_t` and change attribute to `XmlElement`
        [System.Xml.Serialization.XmlElement("Track", typeof(Track_t), IsNullable = false)]
        public List<Track_t> Track
        {
            get { return this._track; }
            set { this._track = value; }
        }
        // Remainder unchanged.
    }
