    public class ReportParameterLookup
    {
        public IList<DatLookupData> Lookup { get; set; }
    }
    public class ReportParameter
    {
        [RequiredIf("Required", true, ErrorMessage = "*")]
        public string ParamValue { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string DefaultValue { get; set; }
        public string CustomProperty { get; set; }
        public string LookupQuery { get; set; }
        public bool Enabled { get; set; }
        public int MaxLength { get; set; }
        public bool Required { get; set; }
        public List<string> Dependence { get; set; }
        public ReportParameterLookup LookupData { get; set; }
        public VariantType Type { get; set; }
        public ReportType Destinations { get; set; }
    }
