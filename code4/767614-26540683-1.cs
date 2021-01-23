    [CollectionDataContract(Name = "Customnamedroot", Namespace = "")]
    public class SearchResults : List<Result>
    {
    }
    
    [DataContract(Name = "Object", Namespace = "")]
    public class Result
    {
        [DataMember(Order = 1, Name = "Something", IsRequired = false)]
        public decimal? Something{ get; set; }
    
        [DataMember(Order = 2, Name = "Anything", IsRequired = true, EmitDefaultValue = false)]
        public DateTime Anything{ get; set; }
    
        [DataMember(Order = 3, Name = "Booleanthing", IsRequired = true, EmitDefaultValue = false)]
        public bool Booleanthing{ get; set; }
    }
