    public class Container
    {
        private Container _parent = null;
        public Container(Container parent, int index)
        {
            _parent = parent;
            Containers = new List<Container>();
            Index = index;
        }
        public List<Container> Containers { get; set; }
        public string ContainerName { get; set; }
        public string Index { get; set; }
    }
