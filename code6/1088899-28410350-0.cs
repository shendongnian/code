     /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
            public partial class Envelope
            {
    
                private EnvelopeBody bodyField;
    
                /// <remarks/>
                public EnvelopeBody Body
                {
                    get
                    {
                        return this.bodyField;
                    }
                    set
                    {
                        this.bodyField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public partial class EnvelopeBody
            {
    
                private OverrideEntriesRequest overrideEntriesRequestField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:Bol:Main:S1:Public")]
                public OverrideEntriesRequest OverrideEntriesRequest
                {
                    get
                    {
                        return this.overrideEntriesRequestField;
                    }
                    set
                    {
                        this.overrideEntriesRequestField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Bol:Main:S1:Public")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:Bol:Main:S1:Public", IsNullable = false)]
            public partial class OverrideEntriesRequest
            {
    
                private OverrideEntriesRequestSessionHeader sessionHeaderField;
    
                private string dataCategoryPathField;
    
                private Entry[] entriesField;
    
                /// <remarks/>
                public OverrideEntriesRequestSessionHeader SessionHeader
                {
                    get
                    {
                        return this.sessionHeaderField;
                    }
                    set
                    {
                        this.sessionHeaderField = value;
                    }
                }
    
                /// <remarks/>
                public string DataCategoryPath
                {
                    get
                    {
                        return this.dataCategoryPathField;
                    }
                    set
                    {
                        this.dataCategoryPathField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlArrayItemAttribute("Entry", Namespace = "urn:Bol:Main:M1:Public", IsNullable = false)]
                public Entry[] Entries
                {
                    get
                    {
                        return this.entriesField;
                    }
                    set
                    {
                        this.entriesField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Bol:Main:S1:Public")]
            public partial class OverrideEntriesRequestSessionHeader
            {
    
                private string appLoginField;
    
                private string appPasswordField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:Bol:Main:Public")]
                public string AppLogin
                {
                    get
                    {
                        return this.appLoginField;
                    }
                    set
                    {
                        this.appLoginField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:Bol:Main:Public")]
                public string AppPassword
                {
                    get
                    {
                        return this.appPasswordField;
                    }
                    set
                    {
                        this.appPasswordField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Bol:Main:M1:Public")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:Bol:Main:M1:Public", IsNullable = false)]
            public partial class Entry
            {
    
                private string entryNameField;
    
                private EntryEntryAttribute[] attributesField;
    
                /// <remarks/>
                public string EntryName
                {
                    get
                    {
                        return this.entryNameField;
                    }
                    set
                    {
                        this.entryNameField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlArrayItemAttribute("EntryAttribute", IsNullable = false)]
                public EntryEntryAttribute[] Attributes
                {
                    get
                    {
                        return this.attributesField;
                    }
                    set
                    {
                        this.attributesField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:Bol:Main:M1:Public")]
            public partial class EntryEntryAttribute
            {
    
                private string nameField;
    
                private string valueField;
    
                /// <remarks/>
                public string Name
                {
                    get
                    {
                        return this.nameField;
                    }
                    set
                    {
                        this.nameField = value;
                    }
                }
    
                /// <remarks/>
                public string Value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }
            }
