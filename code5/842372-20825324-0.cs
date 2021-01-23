    [MetadataType(typeof(ModelAMetadata))]
    public class ModelA
    {
        public virtual string Property { get; set; }
    }
    
    public class ModelAMetadata
    {
        [Required]
        public string Property { get; set; }
    }
    
    [MetadataType(typeof(ModelBMetadata))]
    public class ModelB : ModelA
    {
        public override string Property { get; set; }
    }
    public class ModelBMetadata
    {
        //notice that there is no Required attribute here
        public string Property { get; set; }
    }
