    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", 2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ParentClass {
        
        private ParentClassChildClass[] childClassField;
        
        private string nameField;
        
        private string roleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChildClass",Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ParentClassChildClass[] ChildClass {
            get {
                return this.childClassField;
            }
            set {
                this.childClassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }
    }
