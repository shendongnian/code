        public PropertyId PropId   // Reflect an Int32 backing store to support deserialization of unknown Enum values
        {
            get { return (PropertyId)_propIdValue; } 
            set { _propIdValue = (Int32)value; } 
        }
        [DataMember]
        private Int32 _propIdValue { get; set; }
