    [MetadataType(typeof(TestMetadata))]
    class Test
    {
        public int Id { get; set; }
    }
    class TestMetadata
    {
        [DisplayName("ID")]
        public int Id { get; set; }
    }
