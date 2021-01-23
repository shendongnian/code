    class TaggedSequence
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Last { get; set; }
        [Required]
        [Column(TypeName = "CHAR"), StringLength(1)]
        public string Tag { get; set; }
        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
    
