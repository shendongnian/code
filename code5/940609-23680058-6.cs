    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Map
    {
        private string[] tilesetField;
        private byte widthField;
        private byte heightField;
        private string[] dataField;
        [XmlArrayItemAttribute("tile", IsNullable = false)]
        public string[] tileset
        {
            get
            {
                return tilesetField;
            }
            set
            {
                tilesetField = value;
            }
        }
        public byte width
        {
            get
            {
                return widthField;
            }
            set
            {
                widthField = value;
            }
        }
        public byte height
        {
            get
            {
                return heightField;
            }
            set
            {
                heightField = value;
            }
        }
        [XmlArrayItemAttribute("row", IsNullable = false)]
        public string[] data
        {
            get
            {
                return dataField;
            }
            set
            {
                dataField = value;
            }
        }
    }
