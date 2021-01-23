    [Serializable]
    public class Entry
    {
        private DimensionInfo _dimensionInfo = default(DimensionInfo);
        private Boolean _containsDimensionInfo = true;
        [XmlAttribute("key")]
        public String Key { get; set; }
        [XmlText(typeof(String))]
        public String ContainsDimensionInfo
        {
            get
            {
                return CheckDimensionContaining().ToString().ToLower();
            }
            set
            {
                _containsDimensionInfo = Boolean.Parse(value);
            }
        }
        [XmlIgnore]
        public Boolean ContainsDimensionInfoSpecified
        {
            get { return !CheckDimensionContaining(); }
        }
        [XmlElement("dimensionInfo")]
        public DimensionInfo DimensionInfo
        {
            get { return _dimensionInfo; }
            set { _dimensionInfo = value; }
        }
        [XmlIgnore]
        public Boolean DimensionInfoSpecified
        {
            get { return CheckDimensionContaining(); }
        }
        public Entry()
        {
            Key = String.Empty;
            CheckDimensionContaining();
        }
        private Boolean CheckDimensionContaining()
        {
            return _containsDimensionInfo = _dimensionInfo != default(DimensionInfo);
        }
    }
