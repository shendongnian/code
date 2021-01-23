    {
        [Key, Column(Order = 0)]
        public int Version_Id { get; set; }
        [Key, Column(Order = 1)]
        public int Major { get; set; }
        [Key, Column(Order = 2)]
        public int Minor { get; set; }
        [Key, Column(Order = 3)]
        public int Build { get; set; }
    }
