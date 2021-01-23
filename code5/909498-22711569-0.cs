    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ABC.com/submit")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ABC.com/submit", IsNullable = false)]
    public partial class Request
    {
        private RequestMyData myDataField;
        private string sourceField;
        private System.DateTime dateField;
        /// <remarks/>
        public RequestMyData MyData
        {
            get
            {
                return this.myDataField;
            }
            set
            {
                this.myDataField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link", DataType = "date")]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ABC.com/submit")]
    public partial class RequestMyData
    {
        private RequestMyDataDATA1 dATA1Field;
        private RequestMyDataDATA2 dATA2Field;
        private RequestMyDataDATA3 dATA3Field;
        private string identifierField;
        private decimal valueField;
        /// <remarks/>
        public RequestMyDataDATA1 DATA1
        {
            get
            {
                return this.dATA1Field;
            }
            set
            {
                this.dATA1Field = value;
            }
        }
        /// <remarks/>
        public RequestMyDataDATA2 DATA2
        {
            get
            {
                return this.dATA2Field;
            }
            set
            {
                this.dATA2Field = value;
            }
        }
        /// <remarks/>
        public RequestMyDataDATA3 DATA3
        {
            get
            {
                return this.dATA3Field;
            }
            set
            {
                this.dATA3Field = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public string identifier
        {
            get
            {
               return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public decimal value
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
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ABC.com/submit")]
    public partial class RequestMyDataDATA1
    {
        private decimal valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public decimal value
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
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ABC.com/submit")]
    public partial class RequestMyDataDATA2
    {
        private decimal valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public decimal value
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
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ABC.com/submit")]
    public partial class RequestMyDataDATA3
    {
        private decimal valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.ABC.com/link")]
        public decimal value
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
