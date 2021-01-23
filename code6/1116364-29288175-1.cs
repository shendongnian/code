    class Record
    {
        [Column(Order = 0)]
        public int Id { get; set; }
    
        [Column(Order = 1)]
        public string Category { get; set; }
    
        [Column(Order = 2)]
        public string Description { get; set; }
    }
