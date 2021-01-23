    /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
            public partial class MyDataSet
            {
    
                private MyDataSetQ[] qField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("Q")]
                public MyDataSetQ[] Q
                {
                    get
                    {
                        return this.qField;
                    }
                    set
                    {
                        this.qField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.SerializableAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class MyDataSetQ
            {
    
                private string sKUField;
    
                private string descriptionField;
    
                /// <remarks/>
                public string SKU
                {
                    get
                    {
                        return this.sKUField;
                    }
                    set
                    {
                        this.sKUField = value;
                    }
                }
    
                /// <remarks/>
                public string description
                {
                    get
                    {
                        return this.descriptionField;
                    }
                    set
                    {
                        this.descriptionField = value;
                    }
                }
            }
