    public class Thing
    {
        public IEnumerable<Thing> Children { get; set; }
        public bool IsLeaf => Children == null || !Children.Any();
    }
