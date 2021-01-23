    public abstract class Base
    {
        public abstract int Type { get; }
    }
    public class Foo : Base
    {
        public override int Type { get { return 0; } }
    }
    public class Bar : Base
    {
        public override int Type { get { return 0; } }
    }
