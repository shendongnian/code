    public class Base
    {
        private readonly int type;
        public int Type { get { return type; } }
        protected Base(int type)
        {
            this.type = type;
        }
    }
    public class Foo : Base
    {
        public Foo() : base(0) {}
    }
    public class Bar : Base
    {
        public Bar() : base(1) {}
    }
