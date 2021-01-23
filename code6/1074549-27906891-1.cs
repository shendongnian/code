    public struct MyResult
    {
        private readonly float index;
        private readonly int depth;
        public float Index { get { return index; } }
        public int Depth { get { return depth; } }
        public MyResult(float index, int depth)
        {
            this.index = index;
            this.depth = depth;
        }
        public override bool Equals(object obj)
        { /* not shown, but implemented */ }
        public override int GetHashCode()
        { /* not shown, but implemented */ }
        public override string ToString()
        { /* not shown, but implemented */ }
    }
    
    public class MyClass
    {
        public MyResult Result { get; set; }
    }
