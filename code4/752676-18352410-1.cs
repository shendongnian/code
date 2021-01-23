    [MetadataType(typeof(TestMD))]
    public partial class Test { }
    public partial class TestMD
    {
        [DisplayNameLanguage("Test")]
        public string Prop1 { get; set; }
    }
