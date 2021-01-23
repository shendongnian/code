        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Root
        {
    
            private RootAddress addressField;
    
            private RootReportAReport reportAReportField;
    
            /// <remarks/>
            public RootAddress Address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }
    
            /// <remarks/>
            public RootReportAReport ReportAReport
            {
                get
                {
                    return this.reportAReportField;
                }
                set
                {
                    this.reportAReportField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RootAddress
        {
    
            private ushort postalCodeField;
    
            /// <remarks/>
            public ushort PostalCode
            {
                get
                {
                    return this.postalCodeField;
                }
                set
                {
                    this.postalCodeField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RootReportAReport
        {
    
            private RootReportAReportAddress addressField;
    
            /// <remarks/>
            public RootReportAReportAddress Address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RootReportAReportAddress
        {
    
            private ushort zipField;
    
            /// <remarks/>
            public ushort Zip
            {
                get
                {
                    return this.zipField;
                }
                set
                {
                    this.zipField = value;
                }
            }
        }
