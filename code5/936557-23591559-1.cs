    class MyEntityA
    {
        [Key]
        public int Id { get; set; }
        public int? BId { get; set; }
    
        [ForeignKey("BId")]
        public virtual MyEntityB B { get; set; }
    }
    
    class MyEntityB
    {
        [Key]
        public int Id { get; set; }
    
        public virtual MyEntityA A { get; set; }
    }
