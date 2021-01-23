    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class recipe
    {
        private string titleField;
        private string[] ingredientsField;
        private string[] instructionsField;
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        [System.Xml.Serialization.XmlArrayItemAttribute("li", IsNullable = false)]
        public string[] ingredients
        {
            get
            {
                return this.ingredientsField;
            }
            set
            {
                this.ingredientsField = value;
            }
        }
        [System.Xml.Serialization.XmlArrayItemAttribute("li", IsNullable = false)]
        public string[] instructions
        {
            get
            {
                return this.instructionsField;
            }
            set
            {
                this.instructionsField = value;
            }
        }
    }
