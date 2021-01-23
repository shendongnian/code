    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct HoverStyle
    {
        public bool Bold { get; set; }
        public bool Italicize { get; set; }
        public bool Underline { get; set; }
    }
