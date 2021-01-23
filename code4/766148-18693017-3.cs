    public class Child
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Parent Parent { get; set; }
    }
    
    public class Parent
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
