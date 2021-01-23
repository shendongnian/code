    public partial ModelMetaData
    {
        [Description("This field determines the XYZ blah-de-blah")] // Tooltips
        [StringLength(100)] // Validation
        public string CoolThing { get; set; }
    }
