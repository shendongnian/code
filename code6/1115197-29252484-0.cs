    public partial class List
    {
        private Map[] mapField;
        [XmlElement("Map", typeof(Map), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Map[] Map
        {
            get
            {
                return this.mapField;
            }
            set
            {
                this.mapField = value;
            }
        }
    [...]
    }
