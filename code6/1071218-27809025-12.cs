    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class plan
    {
        private planNagłówek[] itemsField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("nagłówek", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public planNagłówek[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class planNagłówek
    {
        private planNagłówekAutorzy[] autorzyField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("autorzy", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public planNagłówekAutorzy[] autorzy
        {
            get
            {
                return this.autorzyField;
            }
            set
            {
                this.autorzyField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class planNagłówekAutorzy
    {
        private string nazwaField;
        private planNagłówekAutorzyAutor[] autorField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nazwa
        {
            get
            {
                return this.nazwaField;
            }
            set
            {
                this.nazwaField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("autor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public planNagłówekAutorzyAutor[] autor
        {
            get
            {
                return this.autorField;
            }
            set
            {
                this.autorField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class planNagłówekAutorzyAutor
    {
        private string numerField;
        private string imięField;
        private string nazwiskoField;
        private string atrField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string numer
        {
            get
            {
                return this.numerField;
            }
            set
            {
                this.numerField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string imię
        {
            get
            {
                return this.imięField;
            }
            set
            {
                this.imięField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nazwisko
        {
            get
            {
                return this.nazwiskoField;
            }
            set
            {
                this.nazwiskoField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string atr
        {
            get
            {
                return this.atrField;
            }
            set
            {
                this.atrField = value;
            }
        }
    }
