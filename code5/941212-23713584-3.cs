    public class Parent
    {
        public virtual IList<Child> Children { get; set; }
        ...
    
    public class Child
    {
        public virtual Parent Parent { get; set; }
        ...
