    public interface IParent { }
    public class Parent : IParent
    {
        public ParentNested n;
        public Parent()
        {
            n = new ParentNested(this);
        }
    }
    public class Nested
    {
        private IParent _parent;
        public Nested(IParent parent)
        {
            // return "Parent"
            _parent = parent;
        }
    }
    public class ParentNested : Nested
    {
        public ParentNested(IParent parent) : base(parent) { }
    }
