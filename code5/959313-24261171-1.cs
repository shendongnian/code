    class CustomControl
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public List<CustomControl> Children { get; set; }
        public int IndentLevel { get; set; }
    }
