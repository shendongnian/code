        [XmlArrayItem(ElementName = "Meter")]
        [XmlArray(ElementName = "Meters")]
        public Meter [] SerializableMeters
        {
            get
            {
                return Meters.Cast<Meter>().ToArray();
            }
            set
            {
                Meters = new List<IMeter>(value.Cast<IMeter>());
            }
        }
