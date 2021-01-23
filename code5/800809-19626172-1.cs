    class Node
    {
        public string Name { get; private set; }
        public int ID { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }
        public void Test()
        {
            this.Name = "Valid";
            // Works
            this.Next.Name = "Invalid";
        }
    }
    class Other
    {
        public void Test()
        {
            Node node = new Node();
            // Doesn't Work
            node.Name = "Invalid";
        }
    }
