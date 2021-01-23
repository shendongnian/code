    class Parent
    {
        public string Name { get; set; }
        public IEnumerable<string> ChildrenNames { get; set; }
    }
    class Child
    {
        public string ParentName { get; set; }
        public string Name { get; set; }
    }
