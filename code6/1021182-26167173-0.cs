    class Parent
    {
        public int Id { get; set; }
        public List<Child> Children { get; set; }
    }
    
    class Child
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
    
