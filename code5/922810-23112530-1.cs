    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(list))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.oracle.com/webservices/internal/literal")]
    public partial class collection
    {
        
        private object[] itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Order=0)]
        public object[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
