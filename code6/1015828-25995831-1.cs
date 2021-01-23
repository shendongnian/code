      [XmlIgnore]
        public string OtherXML;
        [XmlText]
        [XmlElement(ElementName = "OtherXML")]
        XmlCDataSection OtherXMLAsCdata
        {
            get
            {
                var dummy = new XmlDocument();
                return dummy.CreateCDataSection(OtherXML);
            }
            set
            {
                if (value == null)
                {
                    OtherXML = null;
                    return;
                }
                OtherXML = value.Value;
            }
        }
