    public class Base
    {
        public int SomeInt { get; set; }
    }
    public abstract class BaseChild : Base
    {
        public abstract string Value { get; set; }
    }
    public class ChildChild : BaseChild
    {
        public override string Value { get; set; }
    }
