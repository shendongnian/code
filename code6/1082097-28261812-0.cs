    public class Derived : Base, IAncestor
    {
        public Derived(string message)
        {
            Property = message;
            base.Property = message;
        }
        string IAncestor.Property{get { return Property; }}
    }
