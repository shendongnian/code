    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Map
    {
        private string tilesetField;
        private int wField;
        private int hField;
        private string[] dataField;
        public string tileset
        {
            get
            {
                return this.tilesetField;
            }
            set
            {
                this.tilesetField = value;
            }
        }
        public int w
        {
            get
            {
                return this.wField;
            }
            set
            {
                this.wField = value;
            }
        }
        public int h
        {
            get
            {
                return this.hField;
            }
            set
            {
                this.hField = value;
            }
        }
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public string[] data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }
