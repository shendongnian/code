    public ChildData
    {
        public int Id { get; set; } // primary key
        public int MainClassId { get; set; } // foreign key
        public string Data { get; set; }
    }
    public MainClass
    {
        public int Id { get; set; } // primary key
        public string Data { get; set; }
    }
