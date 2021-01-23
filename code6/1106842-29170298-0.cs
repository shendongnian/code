    public class Action
    {
        public int Id { get; set; }
        
        //Foreign composite key values
        [ForeignKey("DescriptionMaster"), Column(Order = 0)]
        public string Code { get; set; }
        [ForeignKey("DescriptionMaster"), Column(Order = 1)]
        public string Type { get; set; }
        //navigation property
        public virtual DescriptionMaster ActionCodeDescription { get; set; }
    }
    public class DescriptionMaster
    {
        // - get rid of integer Id : public int Id { get; set; }
    
        [Key, Column(Order = 0)]
        public string Code { get; set; }
        [Key, Column(Order = 1)]
        public string Type { get; set; }
        public string Description { get; set; }
    }
