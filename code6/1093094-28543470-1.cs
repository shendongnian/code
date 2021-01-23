    public class Container
    {
        private Container _parent = null;
        public Container(Container parent)
        {
            _parent = parent;
        }
        public List<Container> containers { get; set; }
        public string containerName { get; set; }
        public string index { get; set; }
    }
