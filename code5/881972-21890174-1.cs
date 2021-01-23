    public Type1
    {
        [Key]        
        public int ID { get; set; }
        [ForeignKey("Type2")]
        public int? Type2ID { get; set; }
        public virtual Type2 Type2 { get; set; }
    }
    
    public Type2
    {
        [Key]        
        public int ID { get; set; }
        [ForeignKey("Type1")]
        public int? Type1ID { get; set; }
        public virtual Type1 Type1 { get; set; }
    }
