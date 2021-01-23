    public MyObject{
        public long Id { get; set; }
        public string Name { get; set; }
    
        public ICollection<MyObject> Parents { get; set; }
        public ICollection<MyObject> Children { get; set; }
    }
